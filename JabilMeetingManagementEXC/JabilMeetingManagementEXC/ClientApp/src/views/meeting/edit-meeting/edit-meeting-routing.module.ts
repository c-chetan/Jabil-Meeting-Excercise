import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EditMeetingComponent } from './edit-meeting.component';


const routes: Routes = [
  {
    path: ':id',
    component: EditMeetingComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditMeetingRoutingModule { }
