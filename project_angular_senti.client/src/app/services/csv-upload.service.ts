import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpRequest, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CsvUploadService {
  private apiUrl = 'https://localhost:7100/api/Csv/upload';

  constructor(private http: HttpClient) { }

  uploadCsv(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file);

    return this.http.post(this.apiUrl, formData, {
      headers: new HttpHeaders({}),
      reportProgress: true,
      observe: 'events',
    });
  }
}
