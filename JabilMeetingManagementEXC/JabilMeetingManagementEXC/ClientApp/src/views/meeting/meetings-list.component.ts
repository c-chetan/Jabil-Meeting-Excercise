import { Component, OnInit } from '@angular/core';
import { MeetingService } from '../../services/meeting.service';
import { UserService } from '../../services/user.service';
import { Meeting } from '../../interface/meeting';
import { Attendee } from '../../interface/attendee';
import { User } from '../../interface/user';
import { Router } from '@angular/router';
import { parse } from 'url';

@Component({
  selector: 'app-meeting',
  templateUrl: './meetings-list.component.html',
  styleUrls: ['./meetings-list.component.scss']
})
export class MeetingsListComponent implements OnInit {

  userMeetings: Meeting[];
  meetingAttendees: Attendee[];
  loggedInUserDisplayname: string;
  getUser$: any;
  deleteMeeting$: any;
  loggedInUserId: number;

  constructor(private router: Router,
              private meetingService: MeetingService,
              private userService: UserService
              )
  { }

  ngOnInit() {
    this.loggedInUserId = parseInt(JSON.parse(localStorage.getItem('currentUserId')));
    this.loggedInUserDisplayname = localStorage.getItem('currentUserDisplayName');
    var userMeetings$ = this.meetingService.getUserMeetings(this.loggedInUserId).subscribe(response => {
      if (response)
        this.userMeetings = response;
    });
  }

  navigateToAddMeeting() {
    this.router.navigate(['meetings/add-meeting']);
  }

  editUser(meetingId: any) {
    this.router.navigate(['meetings/edit-meeting/' + meetingId]);
  }

  deleteMeeting(meetingId: number) {
    this.deleteMeeting$ = this.meetingService.removeMeeting(meetingId).subscribe(response => {
      if (response) {
        console.log(response);
      }
    });
  }
}
