import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Meeting } from '../interface/meeting';
import { environment } from '../environments/environment';
import { Attendee } from '../interface/attendee';

@Injectable({
  providedIn: 'root'
})
export class MeetingService {

  private httpOptions: any = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

  constructor(private http: HttpClient) { }

  getUserMeetings(userId: number): Observable<any> {
    return this.http.get<any>(environment.baseApiUrl + '/Meeting/meetings-list/' + userId, this.httpOptions);
  }

  getMeeting(meetingId: number): Observable<any> {
    return this.http.get<Meeting>(environment.baseApiUrl + '/Meeting/' + meetingId, this.httpOptions);
  }

  addNewMeeting(meeting: Meeting): Observable<any> {
    debugger;
    return this.http.post<Meeting>(environment.baseApiUrl + '/Meeting/add-meeting', meeting, this.httpOptions);
  }

  removeMeeting(meetingId: number): Observable<any> {
    return this.http.delete<any>(environment.baseApiUrl + '/Meeting/remove/' +meetingId, this.httpOptions);
  }
}
