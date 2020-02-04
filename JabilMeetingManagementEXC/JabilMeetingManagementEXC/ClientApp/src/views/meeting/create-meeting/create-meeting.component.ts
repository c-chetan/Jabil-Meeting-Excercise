import { Component, OnInit, ViewChild, ElementRef,Input } from '@angular/core';
import { Meeting } from '../../../interface/meeting';
import { User } from '../../../interface/user';
import { MeetingService } from '../../../services/meeting.service';
import { UserService } from 'src/services/user.service';

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
    date: new Date(),
    attendees: []
  }
  currentUserId: number;
  itemList = [];
  selectedAttendees = [];
  settings = {};
  minimumDate = new Date();
  @ViewChild('selectedAttendeesTA', { static: false }) selectedAttendeesEl: ElementRef;

  constructor(private meetingService: MeetingService, private userService: UserService) { }

  ngOnInit() {

    this.currentUserId = JSON.parse(localStorage.getItem('currentUserId'));
    this.getUsers();
    this.selectedAttendees = [];
    this.settings = {
      text: 'Select Attendees',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      classes: 'myclass custom-class',
      labelKey: 'userName',
      primaryKey: 'userId',
      limitSelection: 10
    };
  }

  saveMeeting() {
    debugger;
    this.meeting;
    var meetingOwner = this.meeting.attendees.find(user => user.attendeeId == this.currentUserId);
    //if (meetingOwner) {
    //  this.meeting.attendeesList.
    //}
    var addMeeting$ = this.meetingService.addNewMeeting(this.meeting).subscribe(response => {
      if (response) {
        debugger;
        console.log(response);
      }
    });
  }

  onItemSelect(item: any) {
    console.log(item);
    debugger;
    this.meeting.attendees = [];
    if (this.selectedAttendees && this.selectedAttendees.length > 0) {
      this.meeting.attendees = this.selectedAttendees;
    }
    console.log(this.selectedAttendees);
  }

  OnItemDeSelect(item: any) {
    console.log(item);
    this.meeting.attendees = [];
    this.meeting.attendees = this.selectedAttendees;
    console.log(this.selectedAttendees);
  }

  getUsers() {
    var getUsers$ = this.userService.getUsers().subscribe(response => {
      if (response) {
        this.attendeesListDD = response.value;
        console.log(this.attendeesListDD);
      }
    });
  }

  clearMeetingDetails() {
    this.meeting.subject = '';
    this.meeting.agenda = '';

  }
}
