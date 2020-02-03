import { Component, OnInit } from '@angular/core';
import { MeetingService } from '../../services/meeting.service';
import { Meeting } from '../../interface/meeting';
import { Attendee } from '../../interface/attendee';
import { Router } from '@angular/router';

@Component({
  selector: 'app-meeting',
  templateUrl: './meeting.component.html',
  styleUrls: ['./meeting.component.scss']
})
export class MeetingComponent implements OnInit {

  userMeetings: Meeting[];
  meetingAttendees: Attendee[];

  constructor(private router: Router, private meetingService: MeetingService) { }

  ngOnInit() {
    debugger;

    var userMeetings$ = this.meetingService.getUserMeetings(1).subscribe(response => {
      if (response)
        debugger;

      var meetings = response.map(m => m.Meeting);
      var attendees = meetings.map(a => a.Attendees);
      this.userMeetings = meetings;
      this.meetingAttendees = attendees;
      console.log(meetings);
      console.log(attendees);
    })
  }

  editUser() {
    this.router.navigate(['meetings/add-meeting']);
  }
}
