using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingAppDataLayer.Models
{

    public class Attendee
    {

        [Key]
        public int AttendeeId { get; set; }


        public string AttendeeName { get; set; }

        [Required]
        public bool IsMeetingOwner { get; set; }

        [ForeignKey("UserAttendeeId")]
        public User User { get; set; }

        [ForeignKey("MeetingAttendeeId")]
        public Meeting Meeting { get; set; }
    }
}
