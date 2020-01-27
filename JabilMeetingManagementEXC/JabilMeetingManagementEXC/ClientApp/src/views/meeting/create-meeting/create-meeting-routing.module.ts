import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CreateMeetingComponent } from './create-meeting.component';

const routes: Routes = [
  {
    path: '',
    component: CreateMeetingComponent,
  }
  ]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    RouterModule
  ]
})
export class CreateMeetingRoutingModule { }
