using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeetingAppDataLayer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JabilMeetingManagementEXC.ApiControllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        
        [HttpPost]
        public string AuthenticateUser(User user)
        {
            

            return "";
        }
    }
}
