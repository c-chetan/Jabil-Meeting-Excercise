using System;
using System.Linq;
using System.Collections.Generic;

namespace MeetingAppBL.ViewModel
{
    public class MeetingVM
    {
        public MeetingVM()
        {
            this.Attendees = new List<AttendeeVM>();
        }

        public string Subject { get; set; }

        public int MeetingId { get; set; }
      
        public string Agenda { get; set; }

        public DateTime Date { get; set; }

        public List<AttendeeVM> Attendees { get; set; }

        public List<AttendeeVM> AttendeeList {
            get
            {
                return this.Attendees
                    .Where(a => a.IsMeetingOwner == false)
                    .ToList();
            }
        }

        public AttendeeVM CreatedBy
        {
            get
            {
                return this.Attendees
                    .FirstOrDefault(a => a.IsMeetingOwner == false);
            }
        }
    }
}
