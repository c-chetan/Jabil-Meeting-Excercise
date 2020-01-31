using System;
using System.Collections.Generic;

namespace MeetingAppBL.ViewModel
{
    public class MeetingVM
    {
        public string Subject { get; set; }

        public int MeetingId { get; set; }
      
        public string Agenda { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<AttendeeVM> Attendees { get; set; }

    }
}
