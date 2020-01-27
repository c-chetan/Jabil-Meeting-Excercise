import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateMeetingRoutingModule } from './create-meeting-routing.module';
import { CreateMeetingComponent } from './create-meeting.component';


@NgModule({
  declarations: [
    CreateMeetingComponent
  ],
  imports: [
    CommonModule,
    CreateMeetingRoutingModule
  ]
})
export class CreateMeetingModule { }
