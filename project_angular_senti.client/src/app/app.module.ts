import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SurveypageComponent } from './surveypage/surveypage.component';
import { SurveyCardComponent } from './survey-card/survey-card.component';


@NgModule({
  declarations: [
    AppComponent,
    
    SurveyCardComponent,
   
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,  ReactiveFormsModule,SurveypageComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
