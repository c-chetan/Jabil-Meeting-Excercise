import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateMeetingRoutingModule } from './create-meeting-routing.module';
import { CreateMeetingComponent } from './create-meeting.component';
import { FormsModule } from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';
import { ToastModule } from 'primeng/toast';


@NgModule({
  declarations: [
    CreateMeetingComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    CalendarModule,
    ToastModule,
    AngularMultiSelectModule,
    CreateMeetingRoutingModule
  ],
  exports: [
    CreateMeetingComponent
  ]
})
export class CreateMeetingModule { }
