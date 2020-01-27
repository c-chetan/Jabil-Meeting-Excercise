import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MeetingComponent } from './meeting.component';
import { MeetingRoutingModule } from './meeting-routing.module';


@NgModule({
  declarations: [
    MeetingComponent
  ],
  imports: [
    CommonModule,
    MeetingRoutingModule,
  ]
})
export class MeetingModule { }
