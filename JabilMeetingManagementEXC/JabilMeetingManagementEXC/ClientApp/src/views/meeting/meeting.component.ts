import { Component, OnInit } from '@angular/core';
import { MeetingService } from '../../services/meeting.service';
import { UserService } from '../../services/user.service';
import { Meeting } from '../../interface/meeting';
import { Attendee } from '../../interface/attendee';
import { User } from '../../interface/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-meeting',
  templateUrl: './meeting.component.html',
  styleUrls: ['./meeting.component.scss']
})
export class MeetingComponent implements OnInit {

  userMeetings: Meeting[];
  meetingAttendees: Attendee[];
  user: User;
  getUser$: any;
  constructor(private router: Router,
              private meetingService: MeetingService,
              private userService: UserService
              )
  { }

  ngOnInit() {

    //var userMeetings$ = this.meetingService.getUserMeetings(2).subscribe(response => {
    //  if (response)

    //  var meetings = response.map(m => m.Meeting);
    //  var attendees = meetings.map(a => a.Attendees);
    //  this.userMeetings = meetings;
    //  this.meetingAttendees = attendees;
    //  console.log(meetings);
    //  console.log(attendees);
    //})

    this.getUser$ = this.userService.getUserDetails(1).subscribe(response => {
      if (response) {
        debugger;

      }
    });

  }

  navigateToAddMeeting() {
    this.router.navigate(['meetings/add-meeting']);

  }

  editUser() {
    this.router.navigate(['meetings/add-meeting']);
  }
}
