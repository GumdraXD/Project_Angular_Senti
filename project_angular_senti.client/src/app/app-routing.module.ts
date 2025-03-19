import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HelpusComponent } from './helpus/helpus.component'; // Import the Help page component
import { ReportsComponent } from './reports/reports.component';
import { SurveypageComponent } from './surveypage/surveypage.component';
import { HomeComponent } from './home/home.component'; // Import the Help page component
import { SettingsComponent } from './settings/settings.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';

const routes: Routes = [
  { path: '', component: HomeComponent },  // Default Home Page
  { path: 'help', component: HelpusComponent },
  { path: 'reports', component: ReportsComponent },
  { path: 'settings', component: SettingsComponent },
  { path: 'survey', component: SurveypageComponent },
  { path: 'profile', component: ProfilePageComponent }  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
