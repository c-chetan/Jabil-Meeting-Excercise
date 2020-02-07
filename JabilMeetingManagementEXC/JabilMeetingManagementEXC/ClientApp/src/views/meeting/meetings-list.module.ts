import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MeetingsListComponent } from './meetings-list.component';
import { MeetingRoutingModule } from './meetings-list-routing.module';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    MeetingsListComponent
  ],
  imports: [
    CommonModule,
    TableModule,
    FormsModule,
    ToastModule,
    MeetingRoutingModule,
  ]
})
export class MeetingModule { }
