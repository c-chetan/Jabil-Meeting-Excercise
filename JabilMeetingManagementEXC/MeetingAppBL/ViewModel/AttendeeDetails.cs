using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingAppBL.ViewModel
{
    public class AttendeeDetails
    {
        public int AttendeeId { get; set; }

        public bool IsMeetingOwner { get; set; }

        public int userId { get; set; }

        public int MeetingId { get; set; }

        public UserVM User { get; set; }
    }
}
