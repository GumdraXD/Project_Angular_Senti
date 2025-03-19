import { Component } from '@angular/core';
import { CsvUploadService } from '../services/csv-upload.service';
import { HttpEventType, HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-settings',
  standalone: false,
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css'
})
export class SettingsComponent {
  selectedFile: File | null = null;
  identifierColumn = 'DatasetName';
  progress = 0;
  message = '';
  csvData: string[][] = [];

  constructor(private csvUploadService: CsvUploadService) { }

  onFileSelected(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];

      if (!file.name.endsWith('.csv')) {
        this.message = 'Invalid file type. Please upload a CSV file.';
        this.selectedFile = null;
        this.csvData = [];
        return;
      }

      this.selectedFile = file;
      this.previewCsv(file);
    }
  }

  previewCsv(file: File) {
    const reader = new FileReader();
    reader.onload = (e) => {
      const text = reader.result as string;
      const rows = text.split('\n').map(row => row.split(','));

      this.csvData = rows.slice(0, 5);
    };
    reader.readAsText(file);
  }

  uploadFile() {
    if (!this.selectedFile) {
      this.message = 'Please select a file.';
      return;
    }

    this.progress = 0;
    this.message = 'Uploading...';

    this.csvUploadService.uploadCsv(this.selectedFile, this.identifierColumn).subscribe({
      next: (event) => {
        if (event.type === HttpEventType.UploadProgress && event.total) {
          this.progress = Math.round((100 * event.loaded) / event.total);
        } else if (event instanceof HttpResponse) {
          this.message = event.body.message;
          this.csvData = [];
        }
      },
      error: (err) => {
        this.message = 'Upload failed: ' + err.error.message;
        this.progress = 0;
      }
    });
  }

}
