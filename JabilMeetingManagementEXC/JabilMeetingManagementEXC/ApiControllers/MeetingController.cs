using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeetingAppDataLayer.DAO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JabilMeetingManagementEXC.ApiControllers
{
    [Route("api/[controller]")]
    public class MeetingController : Controller
    {
        
        [HttpGet]
        [Route("meetings-list/{UserId}")]
        public IActionResult GetUserMeetings(int UserId)
        {
            if(UserId!=0)
            {
                MeetingDAO meetingDAO = new MeetingDAO();
                var attendeMeetings = meetingDAO.GetMeetingsList(UserId);

                return Ok(attendeMeetings);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
