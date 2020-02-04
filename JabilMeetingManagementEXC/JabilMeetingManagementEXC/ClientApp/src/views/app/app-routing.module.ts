import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '../../views/login/login.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: 'meetings',
    children: [
      {
        path: 'meetings-list',
        loadChildren: () => import('../meeting/meeting.module').then(m => m.MeetingModule)
      },
      {
        path: 'add-meeting',
        loadChildren: () => import('../meeting/create-meeting/create-meeting.module').then(m => m.CreateMeetingModule)
      },
      {
        path: 'edit-meeting',
        loadChildren: () => import('../meeting/edit-meeting/edit-meeting.module').then(m => m.EditMeetingModule)
      }
    ]
  },
  {
    path: 'user',
    loadChildren: () => import('../user/user.module').then(m => m.UserModule)
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
