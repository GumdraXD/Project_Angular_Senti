import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SurveyService {

  private apiUrl = 'https://localhost:7100/api/survey';

  constructor(private http: HttpClient) { }

  saveSurvey(survey: { FirstName: string, LastName: string }): Observable<any> {
    return this.http.post(this.apiUrl, survey);
  }

  getSurvey(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
}
