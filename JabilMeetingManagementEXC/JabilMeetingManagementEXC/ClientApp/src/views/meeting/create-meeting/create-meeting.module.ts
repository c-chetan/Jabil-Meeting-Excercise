import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateMeetingRoutingModule } from './create-meeting-routing.module';
import { CreateMeetingComponent } from './create-meeting.component';
import { FormsModule } from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';



@NgModule({
  declarations: [
    CreateMeetingComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    CalendarModule,
    AngularMultiSelectModule,
    CreateMeetingRoutingModule
  ],
  exports: [
    CreateMeetingComponent
  ]
})
export class CreateMeetingModule { }
