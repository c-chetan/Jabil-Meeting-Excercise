﻿using System;
using System.Collections.Generic;

namespace MeetingAppBL.ViewModel
{
    public class AttendeeVM
    {

        public int AttendeeId { get; set; }

        public bool IsMeetingOwner { get; set; }

        public int userId { get; set; }
        
        public int MeetingId { get; set; }

        public UserVM User { get; set; }

    }
}
