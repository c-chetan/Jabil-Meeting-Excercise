using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeetingAppBL.DAO;
using AutoMapper;
using MeetingAppBL.ViewModel;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JabilMeetingManagementEXC.ApiControllers
{
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
        public IActionResult GetUserMeetings(int UserId)
        {
            IMapper mappr = _mapper;
            if(UserId!=0)
            {
                MeetingDAO meetingDAO = new MeetingDAO(mappr);
                List<MeetingsListVM> attendeMeetings = meetingDAO.GetUserMeetings(UserId);


                //Avoid Http Response error because of loop attendee-meeting-attendee
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
            IMapper mappr = _mapper;

            if(meetingVM!=null)
            {
                MeetingDAO meetingDAO = new MeetingDAO(mappr);
                var result = meetingDAO.AddMeeting(meetingVM);
                
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
