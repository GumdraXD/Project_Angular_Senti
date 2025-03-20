import { Component } from '@angular/core';
import { CsvUploadService } from '../services/csv-upload.service';
import { HttpEventType } from '@angular/common/http';


// https://angular.dev/guide/forms#data-flow-in-reactive-forms

@Component({
  selector: 'app-surveypage',
  standalone: false,
  templateUrl: './surveypage.component.html',
  styleUrl: './surveypage.component.css'
})
export class SurveypageComponent {

  selectedFile: File | null = null;
  identifierColumn: string = '';
  progress = 0;
  message = '';
  csvData: string[][] = [];

  constructor(private csvUploadService: CsvUploadService) { }

  onFileSelected(event: any): void {
    const file = event.target.files[0];

    if (file && file.type === 'text/csv') {
      this.selectedFile = file;
      this.previewCsv(file);
    } else {
      this.selectedFile = null;
      this.csvData = [];
      this.message = 'Please select a valid CSV file.';
    }
  }

  previewCsv(file: File): void {
    const reader = new FileReader();
    reader.onload = (e: any) => {
      const contents = e.target.result;
      const lines = contents.split('\n');
      this.csvData = lines.map((line: string) => line.split(','));
      this.message = '';
    };
    reader.readAsText(file);
  }

  uploadFile(): void {
    if (this.selectedFile) {
      this.csvUploadService.uploadCsv(this.selectedFile).subscribe({
        next: (event: any) => {
          if (event.type === HttpEventType.UploadProgress && event.total) {
            this.progress = Math.round((100 * event.loaded) / event.total);
          } else if (event.type === HttpEventType.Response) {
            this.message = 'File uploaded successfully!';
            this.progress = 0;
          }
        },
        error: (err) => {
          this.message = `Upload failed: ${err.message}`;
          this.progress = 0;
        }
      });
    }
  }
}
