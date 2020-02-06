import { Component, OnInit, ViewChild, ElementRef,Input } from '@angular/core';
import { Meeting } from '../../../interface/meeting';
import { User } from '../../../interface/user';
import { MeetingService } from '../../../services/meeting.service';
import { UserService } from 'src/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-meeting',
  templateUrl: './create-meeting.component.html',
  styleUrls: ['./create-meeting.component.scss']
})
export class CreateMeetingComponent implements OnInit {

  meetingDate: Date;
  attendeesListDD: User[] = [];
  @Input() meeting: Meeting = {
    meetingId: 0,
    subject: '',
    agenda: '',
    attendeesNames: '',
    date: new Date(),
    attendees: []
  }
  currentUserId: number;
  itemList = [];
  @Input() selectedAttendees = [];
  settings = {};
  minimumDate = new Date();
  @ViewChild('selectedAttendeesTA', { static: false }) selectedAttendeesEl: ElementRef;

  constructor(private meetingService: MeetingService, private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.currentUserId = JSON.parse(localStorage.getItem('currentUserId'));
    this.getUsers();
    this.selectedAttendees = [];
    this.settings = {
      text: 'Select atleast 1 Attendee',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      classes: 'myclass custom-class',
      noDataLabel: 'No Attendees',
      labelKey: 'displayName',
      primaryKey: 'userId',
      limitSelection: 10,
      minSelectionLimit:1
    };
  }

  saveMeeting() {
    debugger;
    //this.meeting.date = 
    if (this.meeting && this.meeting.attendees.length > 1) {
      //JSON.stringify(this.meeting.date);
      var addMeeting$ = this.meetingService.addNewMeeting(this.meeting).subscribe(response => {
        if (response && response.value > 0) {
          debugger;
          console.log(response);
          this.router.navigate(['meetings/meetings-list']);
        }
      });
    }
    else {
      console.log(this.meeting);
    }
  }

  onItemSelect(item: any) {
    this.meeting.attendees = [];
    if (this.selectedAttendees && this.selectedAttendees.length > 0) {
      this.meeting.attendees = this.selectedAttendees;
    }
  }

  OnItemDeSelect(item: any) {
    this.meeting.attendees = [];
    this.meeting.attendees = this.selectedAttendees;
  }

  getUsers() {
    var getUsers$ = this.userService.getUsers().subscribe(response => {
      if (response) {
        this.attendeesListDD = response.value;
      }
    });
  }

  clearMeetingDetails() {
    this.meeting.subject = '';
    this.meeting.agenda = '';
    this.selectedAttendees = [];

  }
}
