using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MeetingAppDataLayer.Models;
using MeetingAppDataLayer.DBContext;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MeetingAppBL.ViewModel;
using MeetingAppDataLayer;

namespace MeetingAppBL.DAO
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

        public List<MeetingsListVM> GetUserMeetings(int Id)
        {
            if(Id!=0)
            {
                using(MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {

                    //var userMeetings = dBContext.Attendees
                    //                    .Include(a => a.Meeting)
                    //                    .Include(m => m.Meeting.Attendees)
                    //                    .Where(x => x.User.UserId == Id)
                    //                    .ToList();

                    var userMeetings = dBContext.Meetings
                                           .Include(m => m.Attendees.Select(u => u.User))
                                           //.ThenInclude(u => u.ch)
                                           //.Include(m => m.Attendees.Select(a => a.User))
                                           .Where(m => m.Attendees.Where(a => a.User.UserId == Id).Any())
                                           .ToList();
                                           //.Select(a => new MeetingsListVM() {
                                           //    Subject = a.Subject,
                                           //    Attendees = string.Join(';', m.Attendees.Select(u => u.User.UserName).ToList()),
                                           //    MeetingDate = a.Date,
                                           //    Agenda = a.Agenda
                                           //})
                    //.Select(m => new MeetingsListVM() {
                    //    MeetingId = m.MeetingId,
                    //    Subject = m.Subject,
                    //    Attendees = string.Join(';', m.Attendees.Select(a => a.User.UserName).ToList()),
                    //    MeetingDate = m.Date,
                    //    Agenda = m.Agenda
                    //})
                    //.ToList();

                    //dBContext.(userMeetings)
                    //    .Collection(m => m.)

                    //userMeetings.ForEach(m => {
                    //    var listAttendees = m.Attendees.Select(a => a.User.UserName).ToList();

                    //    var commaAttendeesName = string.Join(';', listAttendees);
                    //var userMeetingsVM = _mapper.Map<List<Attendee>, List<AttendeeVM>>(userMeetings);
                    //s});

                    //var userMeetingsVM = _mapper.Map<List<Attendee>,List<AttendeeVM>>(userMeetings);

                    return new List<MeetingsListVM>();
                    //return userMeetings;
                    //return userMeetingsVM;
                }
            }
            else
            {
                return new List<MeetingsListVM>();
            }
        }

        public int AddMeeting(MeetingVM meetingVM)
        {
            if(meetingVM!= null)
            {
                using(MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {

                    var meeting = _mapper.Map<Meeting>(meetingVM);

                    var query = dBContext.Meetings.Add(meeting);
                    dBContext.SaveChanges();

                    var addedMeetingDetails = dBContext.Meetings.Where(m => m.Subject == meeting.Subject).First();
                    int newAddedMeetingId = addedMeetingDetails.MeetingId;

                    return newAddedMeetingId;
                }
            }
            else
            {
                return 0;
            }
        }
        
    }
}
