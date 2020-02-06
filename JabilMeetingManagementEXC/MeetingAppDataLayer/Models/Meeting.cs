using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingAppDataLayer.Models
{

    public class Meeting
    {

        [Key]
        public int MeetingId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="The {0} must be atleast {2} characters long.", MinimumLength = 5)]
        public string Subject { get; set; }

        [Required]
        public string Agenda { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public List<Attendee> Attendees { get; set; }
    }
}
