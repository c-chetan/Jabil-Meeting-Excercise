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

        [Required]
        public bool IsMeetingOwner { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int UserId { get; set; }


        [ForeignKey("MeetingId")]
        public Meeting Meeting { get; set; }

        public int MeetingId { get; set; }
        
    }
}
