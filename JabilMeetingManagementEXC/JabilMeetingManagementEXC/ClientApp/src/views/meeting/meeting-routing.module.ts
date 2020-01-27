import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { MeetingComponent } from './meeting.component';
import { CreateMeetingComponent } from '../meeting/create-meeting/create-meeting.component';

const routes: Routes = [
  {
    path: '',
    component: MeetingComponent,
    children: [
      {
        path: 'add-meeting',
        component: CreateMeetingComponent 
      }
    ]
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class MeetingRoutingModule { }
