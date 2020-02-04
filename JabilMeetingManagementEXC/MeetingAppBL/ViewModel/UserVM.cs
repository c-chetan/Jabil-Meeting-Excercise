using System;

namespace MeetingAppBL.ViewModel
{
    public class UserVM
    {
        public int UserId { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Password { get; set; }

        public string userToken { get; set; }
    }
}
