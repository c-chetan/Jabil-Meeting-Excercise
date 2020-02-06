using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MeetingAppBL.DAO;
using AutoMapper;
using MeetingAppBL.ViewModel;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JabilMeetingManagementEXC.ApiControllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class MeetingController : Controller
    {
        private readonly IMapper _mapper;
        
        public MeetingController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Route("meetings-list/{UserId}")]
        public IActionResult GetMeetings(int UserId)
        {

            IMapper mappr = _mapper;
            if(UserId!=0)
            {

                MeetingDAO meetingDAO = new MeetingDAO(mappr);
                List<MeetingsListVM> attendeMeetings = meetingDAO.GetUserMeetings(UserId);


                //Avoid Http Response error because of loop attendee-meeting-attendee 
                //Can also register at service level if looping happens at multiple places
                var jsonOptions = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                return Json(attendeMeetings, jsonOptions);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add-meeting")]
        public IActionResult CreateMeeting([FromBody]MeetingVM meetingVM)
        {

            var userClaims = User.Claims;
            var currentUser = userClaims
                                    .Where(c => c.Type == "UserId")
                                    .FirstOrDefault();
            int currentUserId = Int32.Parse(currentUser.Value);


            IMapper mappr = _mapper;

            if(meetingVM!=null)
            {
                MeetingDAO meetingDAO = new MeetingDAO(mappr);
                int meetingId = meetingDAO.AddMeeting(meetingVM, currentUserId);
                
                return Ok(new JsonResult(meetingId));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{meetingId}")]
        public IActionResult GetMeetingDetails(int meetingId)
        {
            IMapper mappr = _mapper;

            if (meetingId !=0 )
            {
                MeetingDAO meetingDAO = new MeetingDAO(mappr);
                MeetingVM meeting = meetingDAO.GetMeeting(meetingId);

                return Ok(new JsonResult(meeting));

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("remove/{meetingId}")]
        public IActionResult RemoveMeeting(int meetingId)
        {
            IMapper mappr = _mapper;

            if(meetingId!=0)
            {
                MeetingDAO meetingDAO = new MeetingDAO(mappr);
                int removedMeetingId = meetingDAO.RemoveMeeting(meetingId);
                return Ok(new JsonResult(removedMeetingId));
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
