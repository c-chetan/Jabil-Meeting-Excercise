import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '../../views/login/login.component';
import { DefaultLayoutComponent } from '../shared-layout/default-layout.component';
import { AuthGuard } from 'src/guards/auth-guard';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '',
    redirectTo: 'meetings/meetings-list',
    pathMatch: 'full'
  },
  {
    path: 'meetings',
    component: DefaultLayoutComponent,
    children: [
      {
        path: 'meetings-list',
        loadChildren: () => import('../meeting/meetings-list.module').then(m => m.MeetingModule)
      },
      {
        path: 'add-meeting',
        loadChildren: () => import('../meeting/create-meeting/create-meeting.module').then(m => m.CreateMeetingModule)
      },
      {
        path: 'edit-meeting',
        loadChildren: () => import('../meeting/edit-meeting/edit-meeting.module').then(m => m.EditMeetingModule)
      }
    ],
    canActivate: [AuthGuard]
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
