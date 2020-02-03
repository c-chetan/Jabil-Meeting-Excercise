import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
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
  attendees: User[] = [];
  meeting: Meeting = {
    meetingId: 0,
    subject: '',
    agenda: '',
    date: new Date()
  }

  itemList = [];
  selectedAttendees = [];
  settings = {};
  @ViewChild('selectedAttendeesTA', { static: false }) selectedAttendeesEl: ElementRef;

  constructor(private meetingService: MeetingService, private userService: UserService) { }

  ngOnInit() {

    this.getUsers();

    this.selectedAttendees = [];

    this.settings = {
      text: 'Select Attendees',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      classes: 'myclass custom-class',
      labelKey: 'userName',
      primaryKey: 'userId'
    };
  }

  saveMeeting(val: any) {
    this.meeting;
    var addMeeting$ = this.meetingService.addNewMeeting(this.meeting).subscribe(response => {
      if (response) {
        debugger;
        console.log(response);
      }
    });
  }

  onItemSelect(item: any) {
    console.log(item);
    console.log(this.selectedAttendees);
  }

  OnItemDeSelect(item: any) {
    console.log(item);
    console.log(this.selectedAttendees);
  }
  getUsers() {

    var getUsers$ = this.userService.getUsers().subscribe(response => {

      if (response) {
        debugger;
        this.attendees = response.value;
        console.log(this.attendees);
      }
    });
  }


}
