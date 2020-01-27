import { Component, OnInit } from '@angular/core';
import { User } from '../../interface/user';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user: User = {
    userCode: '',
    userName: '',
    password: ''
  };
  authenticateUser$: any;

  constructor(private router: Router, private userService: UserService) { }



  ngOnInit() {
  }

  onSubmit(user: any) {
    this.user.userName = user.usrName;
    this.user.password = user.passw;
    this.authenticateUser$ = this.userService.authUser(this.user).subscribe(response => {
      if (response) {
        debugger;
        console.log(response);
        this.router.navigate(['/meetings']);
      }
    });
  }
}