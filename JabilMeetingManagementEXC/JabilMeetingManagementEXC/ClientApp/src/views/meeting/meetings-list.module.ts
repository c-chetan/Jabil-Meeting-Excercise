import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MeetingsListComponent } from './meetings-list.component';
import { MeetingRoutingModule } from './meetings-list-routing.module';
import { TableModule } from 'primeng/table';

@NgModule({
  declarations: [
    MeetingsListComponent
  ],
  imports: [
    CommonModule,
    TableModule,
    MeetingRoutingModule,
  ]
})
export class MeetingModule { }
