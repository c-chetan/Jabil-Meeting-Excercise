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
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        public string Agenda { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public List<Attendee> Attendees { get; set; }
    }
}
