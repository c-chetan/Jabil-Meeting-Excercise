using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingAppBL.ViewModel
{
    public class MeetingsListVM
    {

        public int MeetingId { get; set; }

        public string Subject { get; set; }

        public string AttendeesNames { get; set; }

        public DateTime MeetingDate { get; set; }

        public string Agenda { get; set; }
    }
}
