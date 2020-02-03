using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MeetingAppDataLayer.Models;
using MeetingAppDataLayer.DBContext;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MeetingAppBL.ViewModel;

namespace MeetingAppDataLayer.DAO
{
    public class MeetingDAO
    {
        private readonly IMapper _mapper;
        private readonly AppSettings appSettings;

        public MeetingDAO(IMapper mapper)
        {
            appSettings = new AppSettings();
            _mapper = mapper;
        }

        public List<AttendeeVM> GetMeetingsList(int Id)
        {
            if(Id!=0)
            {
                using(MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {

                    var userMeetings = dBContext.Attendees
                                        .Include(a => a.Meeting)
                                        .Include(m => m.Meeting.Attendees)
                                        .Where(x => x.User.UserId == Id)
                                        .ToList();
                    
                    var userMeetingsVM = _mapper.Map<List<Attendee>,List<AttendeeVM>>(userMeetings);


                    return userMeetingsVM;
                }
            }
            else
            {
                return new List<AttendeeVM>();
            }
        }

        public bool AddMeeting(MeetingVM meetingVM)
        {
            if(meetingVM!= null)
            {
                using(MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {

                    var meeting = _mapper.Map<Meeting>(meetingVM);

                    var query = dBContext.Meetings.Add(meeting);

                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        
    }
}
