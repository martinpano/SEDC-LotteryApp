import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router'
import { WinnersListComponent } from '../winners-list/winners-list.component';
import { SubmitCodeComponent } from '../submit-code/submit-code.component';


const routes: Routes = [
  { path: 'submit-code', component: SubmitCodeComponent },
  { path: 'winners', component: WinnersListComponent },
  {path: '', component: WinnersListComponent}
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class AppRoutingModule { }
