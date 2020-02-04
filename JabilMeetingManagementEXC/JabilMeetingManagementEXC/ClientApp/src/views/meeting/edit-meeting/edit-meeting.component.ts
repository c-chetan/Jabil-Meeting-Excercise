import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MeetingService } from '../../../services/meeting.service';
import { Meeting } from 'src/interface/meeting';

@Component({
  selector: 'app-edit-meeting',
  templateUrl: './edit-meeting.component.html',
  styleUrls: ['./edit-meeting.component.scss']
})
export class EditMeetingComponent implements OnInit {

  meetingToEditId: number;
  meetingToEdit: Meeting;
  maskedMeetingDate: string;
  constructor(private activatedRoute: ActivatedRoute, private meetingService: MeetingService) { }

  ngOnInit() {
    this.meetingToEdit = {
      meetingId: 0,
      subject: '',
      agenda: '',
      date: new Date(),
      attendees: []
    }
    debugger;
    //this.meetingToEditId = parseInt(this.activatedRoute.params.value.id);
    var getIdFromRoute = this.activatedRoute.params.subscribe(response => {
      console.log(response);
      this.meetingToEditId = parseInt(response.id);
      this.getMeeting(this.meetingToEditId);
    });
  }

  getMeeting(meetingId) {

    if (meetingId && meetingId > 0) {
      var getMeeting$ = this.meetingService.getMeeting(meetingId).subscribe(response => {
        if (response) {
          debugger;
          this.meetingToEdit = response.value;
          this.meetingToEdit.date = new Date(response.value.date);
          
          //let day = meetingDate.getDate();
          //let month = meetingDate.getMonth() + 1;
          //let year = meetingDate.getFullYear();
          //this.maskedMeetingDate = day + '/' + month + '/' + 'year';

        }
      });
    }
  }

}
