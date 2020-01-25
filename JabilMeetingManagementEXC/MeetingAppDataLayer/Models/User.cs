using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingAppDataLayer.Models
{
    [Table("AuthUser")]
    public class User
    {

        [Key]
        public int UserId { get; set; }

        public string UserCode { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
