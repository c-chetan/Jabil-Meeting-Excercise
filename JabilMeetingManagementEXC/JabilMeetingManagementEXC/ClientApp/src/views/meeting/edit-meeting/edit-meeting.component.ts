import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MeetingService } from '../../../services/meeting.service';
import { Meeting } from 'src/interface/meeting';
import { User } from 'src/interface/user';

@Component({
  selector: 'app-edit-meeting',
  templateUrl: './edit-meeting.component.html',
  styleUrls: ['./edit-meeting.component.scss']
})
export class EditMeetingComponent implements OnInit {

  meetingToEditId: number;
  meetingToEdit: Meeting;
  existingUsers: User[];
  getIdFromRoute$: any;
  getMeeting$: any;
  maskedMeetingDate: string;
  constructor(private activatedRoute: ActivatedRoute, private meetingService: MeetingService) { }

  ngOnInit() {
    this.meetingToEdit = {
      meetingId: 0,
      subject: '',
      agenda: '',
      attendeesNames: '',
      date: new Date(),
      attendees: []
    }
    this.existingUsers = [];
    //this.meetingToEditId = parseInt(this.activatedRoute.params.value.id);
    this.getIdFromRoute$ = this.activatedRoute.params.subscribe(response => {
      this.meetingToEditId = parseInt(response.id);
      this.getMeeting(this.meetingToEditId);
    });
  }

  getMeeting(meetingId) {

    if (meetingId && meetingId > 0) {
      this.getMeeting$ = this.meetingService.getMeeting(meetingId).subscribe(response => {
        if (response) {
          this.meetingToEdit = response.value;
          this.meetingToEdit.date = new Date(response.value.date);
          this.existingUsers = response.value.attendees.map(x => x.user);
        }
      });
    }
  }

}
