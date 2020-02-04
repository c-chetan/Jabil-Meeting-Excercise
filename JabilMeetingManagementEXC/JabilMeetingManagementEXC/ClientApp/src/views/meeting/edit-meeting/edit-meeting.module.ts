import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateMeetingModule } from '../create-meeting/create-meeting.module';
import { EditMeetingRoutingModule } from './edit-meeting-routing.module';
import { EditMeetingComponent } from './edit-meeting.component';


@NgModule({
  declarations: [EditMeetingComponent],
  imports: [
    CommonModule,
    CreateMeetingModule,
    EditMeetingRoutingModule
  ]
})
export class EditMeetingModule { }
