using System;
using System.Collections.Generic;

namespace JabilMeetingManagementEXC.ViewModel
{
    public class MeetingVM
    {
        public string Subject { get; set; }

        public int MeetingId { get; set; }
      
        public string MeetingAgenda { get; set; }

        public DateTime MeetingDate { get; set; }

        public IEnumerable<AttendeeVM> Attendees { get; set; }

    }
}
