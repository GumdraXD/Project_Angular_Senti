import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SurveypageComponent } from './surveypage/surveypage.component';
import { SurveyCardComponent } from './survey-card/survey-card.component';
import { HelpusComponent } from './helpus/helpus.component';
import { HomeComponent } from './home/home.component';
import { MovableWidgetComponent } from './movable-widget/movable-widget.component';
import { ReportsComponent } from './reports/reports.component';
import { SettingsComponent } from './settings/settings.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';


@NgModule({
  declarations: [
    AppComponent,
    SurveypageComponent,
    SurveyCardComponent,
    HelpusComponent,
    HomeComponent,
    MovableWidgetComponent,
    ReportsComponent,
    SettingsComponent,
    ProfilePageComponent,
   
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
