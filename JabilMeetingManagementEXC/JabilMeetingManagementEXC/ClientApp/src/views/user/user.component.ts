import { Component, OnInit } from '@angular/core';
import { User } from '../../interface/user';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  user: User;
  addUser$: any;
  tempConfirmPassword: string = '';

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.user = {
      userCode: '',
      userName: '',
      displayName: '',
      password: '',
      userToken: ''
    }
  }

  SignupUser(userDetails: any) {
    this.user = {
      userCode: userDetails.value.newDisplayName.substring(0, 3),
      userName: userDetails.value.newUserName,
      displayName: userDetails.value.newDisplayName,
      password: userDetails.value.newPas,
      userToken: ''
    }
    if (this.user && this.user.userName != '' && this.user.password != '') {
      this.addUser$ = this.userService.signupUser(this.user).subscribe(response => {
        if (response) {
          this.router.navigate(['login']);
        }
      });
    }
  }
}
