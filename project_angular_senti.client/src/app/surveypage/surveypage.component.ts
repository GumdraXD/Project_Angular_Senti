import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-surveypage',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './surveypage.component.html',
  styleUrls: ['./surveypage.component.css']
})
export class SurveypageComponent implements OnInit {
  surveyQuestions = [
    { question: 'Was the event staff professional and courteous?', type: 'scale' },
    { question: 'Was the event staff knowledgeable?', type: 'scale' },
    { question: 'Did the services provided meet your needs?', type: 'scale' },
    { question: 'How helpful was the event staff at the event?', type: 'scale' },
    { question: 'How satisfied are you with the Group Event?', type: 'scale' },
    { question: 'Any additional comments concerning the group event experience?', type: 'text' },
    { question: 'Would you like someone from QTC to contact you about your exam service?', type: 'yesno' }
  ];

  myForm: FormGroup = new FormGroup({});

  ngOnInit() {
    this.myForm = new FormGroup(this.createFormControls());
  }

  private createFormControls(): { [key: string]: FormControl } {
    return this.surveyQuestions.reduce((acc, item) => {
      acc[item.question] = this.createFormControl(item.type);
      return acc;
    }, {} as { [key: string]: FormControl });
  }

  private createFormControl(type: string): FormControl {
    switch (type) {
      case 'scale':
      case 'yesno':
        return new FormControl('', Validators.required);
      case 'text':
        return new FormControl('', Validators.maxLength(200));
      default:
        return new FormControl('');
    }
  }

  onSubmit(): void {
    if (this.myForm.valid) {
      console.log('Survey Data:', this.myForm.value);
    } else {
      console.log('Form is invalid');
    }
  }
}
