using System;
using System.Collections.Generic;

namespace JabilMeetingManagementEXC.ViewModel
{
    public class AttendeeVM
    {

        public int AttendeeId { get; set; }

        public string AttendeeName { get; set; }

        public bool IsMeetingOwner { get; set; }
        
        public UserVM User { get; set; }
        
        public MeetingVM Meeting { get; set; }
    }
}
