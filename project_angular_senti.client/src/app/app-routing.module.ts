import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SurveypageComponent } from './surveypage/surveypage.component';

const routes: Routes = [
  { path: 'survey', component: SurveypageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
