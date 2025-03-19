import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CsvUploadService {
  private apiUrl = 'https://localhost:7100/api/survey';

  constructor(private http: HttpClient) { }

  uploadCsv(file: File, identifierColumn: string): Observable<HttpEvent<any>> {
    const formData = new FormData();
    formData.append('file', file);
    formData.append('identifierColumn', identifierColumn);

    const req = new HttpRequest('POST', this.apiUrl, formData, {
      reportProgress: true,
      responseType: 'json',
    });

    return this.http.request(req);
  }
}
