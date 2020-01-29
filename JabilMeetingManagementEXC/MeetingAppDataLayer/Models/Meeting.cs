using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingAppDataLayer.Models
{

    public class Meeting
    {

        [Key]
        public int MeetingId { get; set; }

        [Required]
        [MaxLength(50)]
        public string MeetingSubject { get; set; }

        [Required]
        public string MeetingAgenda { get; set; }

        [Required]
        public DateTime MeetingDate { get; set; }

        [Required]
        public IEnumerable<Attendee> Attendees { get; set; }
    }
}
