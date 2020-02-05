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
  deleteMeeting$: any;
  loggedInUserId: number;

  constructor(private router: Router,
              private meetingService: MeetingService,
              private userService: UserService
              )
  { }

  ngOnInit() {

    this.loggedInUserId = parseInt(JSON.parse(localStorage.getItem('currentUserId')));

    var userMeetings$ = this.meetingService.getUserMeetings(this.loggedInUserId).subscribe(response => {
      debugger;
      if (response)
      //var meetings = response;
      //var meetings = response.map(m => m.Meeting);
      //var attendees = meetings.map(a => a.Attendees);
        this.userMeetings = response;
      //this.meetingAttendees = attendees;
    })

    //this.getUser$ = this.userService.getUserDetails(this.loggedInUserId).subscribe(response => {
    //  if (response) {
    //  }
    //});

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
