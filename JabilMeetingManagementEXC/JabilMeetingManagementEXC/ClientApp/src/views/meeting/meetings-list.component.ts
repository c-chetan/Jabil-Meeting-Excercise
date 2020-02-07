import { Component, OnInit } from '@angular/core';
import { MeetingService } from '../../services/meeting.service';
import { UserService } from '../../services/user.service';
import { Meeting } from '../../interface/meeting';
import { Attendee } from '../../interface/attendee';
import { User } from '../../interface/user';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-meeting',
  templateUrl: './meetings-list.component.html',
  styleUrls: ['./meetings-list.component.scss'],
  providers: [MessageService]
})
export class MeetingsListComponent implements OnInit {

  userMeetings: Meeting[];
  meetingAttendees: Attendee[];
  loggedInUserDisplayname: string;
  getUser$: any;
  deleteMeeting$: any;
  loggedInUserId: number;
  showMeetingDetailsCard: boolean = false;
  meetingDetails: Meeting = {
    meetingId: 0,
    subject: '',
    agenda: '',
    attendeesNames: '',
    date: new Date(),
    attendees: []
  };

  constructor(private router: Router,
              private meetingService: MeetingService,
              private userService: UserService,
              private messageService: MessageService
              )
  { }

  ngOnInit() {
    this.loggedInUserId = parseInt(JSON.parse(localStorage.getItem('currentUserId')));
    this.loggedInUserDisplayname = localStorage.getItem('currentUserDisplayName');
    var userMeetings$ = this.meetingService.getUserMeetings(this.loggedInUserId).subscribe(response => {
      if (response && response.length > 0)
      this.userMeetings = response;
      //this.messageService.add({ severity: 'success', key: 'meetingsLoadedSuccess', summary: 'Meetings Loaded' });
      this.messageService.add(
        {
          severity: 'warn', key: 'attendeeMeetingsAlert',
          summary: 'You have ' + response.length + ' meeting/s to attend.',
          life: 10000
        });
    });
  }

  navigateToAddMeeting() {
    this.router.navigate(['meetings/add-meeting']);
  }

  editUser(meetingId: any) {
    this.router.navigate(['meetings/edit-meeting/' + meetingId]);
  }

  //openConfirmationToast(meetingId: number) {
  //  debugger;
  //  this.messageService.add({ severity: 'error', key: 'delMeetingConfirmToast', data: meetingId });
  //}

  deleteMeeting(meetingId: number) {
    debugger;
    this.deleteMeeting$ = this.meetingService.removeMeeting(meetingId).subscribe(response => {
      if (response) {
        window.location.reload();
        this.messageService.add({ severity: 'success', summary: 'Meeting Deleted Successfully.' });
      }
    });
  }

  showMeetingDetails(meeting: any, index: number) {
    if (meeting && meeting != undefined) {
      this.showMeetingDetailsCard = true;
      this.meetingDetails.meetingId = meeting.MeetingId;
      this.meetingDetails.subject = meeting.Subject;
      this.meetingDetails.agenda = meeting.Agenda;
      this.meetingDetails.attendeesNames = meeting.AttendeesNames;
      this.meetingDetails.date = meeting.MeetingDate;
    }
  }

  closeMeetingDetailsCard() {
    this.showMeetingDetailsCard = false;
  }
}
