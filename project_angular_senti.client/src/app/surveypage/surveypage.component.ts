import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { SurveyService } from '../services/survey.service';

// https://angular.dev/guide/forms#data-flow-in-reactive-forms

@Component({
  selector: 'app-surveypage',
  standalone: false,
  templateUrl: './surveypage.component.html',
  styleUrl: './surveypage.component.css'
})
export class SurveypageComponent {
  survey = { FirstName: '', LastName: '' };
  message = '';

  saveData() {
    this.surveyService.saveSurvey(this.survey).subscribe({
      next: () => this.message = 'Data saved successfully!',
      error: () => this.message = 'Error saving data!'
    });
  }
  /* Constructor used during the testing
  constructor(private userService: UserService) { } */
  constructor(private surveyService: SurveyService) { }

}
