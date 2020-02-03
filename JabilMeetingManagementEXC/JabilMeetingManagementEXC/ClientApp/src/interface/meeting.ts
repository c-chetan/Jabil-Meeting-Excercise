import { Attendee } from './attendee';

export interface Meeting {
  subject: string,
  meetingId: number,
  agenda: string,
  date: Date,
  attendees: Attendee[]
}
