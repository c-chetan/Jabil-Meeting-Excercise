import { Component, OnInit } from '@angular/core';
import { User } from '../../interface/user';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [MessageService]
})
export class LoginComponent implements OnInit {

  user: User = {
    userCode: '',
    userName: '',
    displayName: '',
    password: '',
    userToken: ''
  };
  hideloginErrorLabel: boolean = false;
  authenticatedUser: boolean = true;
  authenticateUser$: any;

  constructor(private router: Router,
              private userService: UserService,
              private messageService: MessageService) { }



  ngOnInit() {
  }

  onSubmit(user: any) {
    if (user.usrName != '' && user.passw != '' && user.usrName != undefined && user.passw != undefined) {
      this.user.userName = user.usrName;
      this.user.password = user.passw;
      this.authenticateUser$ = this.userService.authUser(this.user).subscribe(response => {
        if (response && response.value.userToken != null) {
          this.router.navigate(['/meetings/meetings-list']);
          JSON.stringify(localStorage.setItem('currentUserId', response.value.userId));
          JSON.stringify(localStorage.setItem('currentUserDisplayName', response.value.displayName));
          JSON.stringify(localStorage.setItem('jwtToken', response.value.userToken));
        }
        else {
          this.hideloginErrorLabel = true;
          //this.messageService.add({ severity: 'error', summary: 'Invalid Credentials.' });
        }
      });
    }
    else {
      this.messageService.add({ severity: 'error', summary: 'Username or Password not Entered.' });
    }
  }
  passwordInputKeyEvent() {
    this.hideloginErrorLabel = false;
  }
  NavigatesignUp() {
    this.router.navigate(['user']);
  }
}
