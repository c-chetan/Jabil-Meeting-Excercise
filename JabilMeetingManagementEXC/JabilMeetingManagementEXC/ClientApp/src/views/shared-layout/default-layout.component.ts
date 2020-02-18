import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-default-layout',
  templateUrl: './default-layout.component.html',
  styleUrls: ['./default-layout.component.scss']
})
export class DefaultLayoutComponent implements OnInit {

  loggedInUser: string;

  constructor(private router: Router) { }

  ngOnInit() {
    this.loggedInUser = localStorage.getItem('currentUserDisplayName');
  }

  logOutUser() {
    //debugger;
    localStorage.removeItem('jwtToken');
    localStorage.removeItem('currentUserDisplayName');
    localStorage.removeItem('currentUserId');
    this.router.navigate(['login']);
  }

}
