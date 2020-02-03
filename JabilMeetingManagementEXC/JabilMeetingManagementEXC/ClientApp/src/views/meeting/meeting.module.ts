import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MeetingComponent } from './meeting.component';
import { MeetingRoutingModule } from './meeting-routing.module';
import { TableModule } from 'primeng/table';

@NgModule({
  declarations: [
    MeetingComponent
  ],
  imports: [
    CommonModule,
    TableModule,
    MeetingRoutingModule,
  ]
})
export class MeetingModule { }
