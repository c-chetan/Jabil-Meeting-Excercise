using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MeetingAppDataLayer.Models;
using MeetingAppDataLayer.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
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
            if (Id != 0)
            {
                using (MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {

                    //var userMeetings = dBContext.Attendees
                    //                    .Include(a => a.Meeting)
                    //                    .Include(m => m.Meeting.Attendees)
                    //                    .ThenInclude(a => a.User)
                    //                    .Where(x => x.User.UserId == Id)
                    //                    .ToList();



                    //Working Code for Meeting > Attendees > Users
                    //var userMeetings = dBContext.Meetings
                    //                       .Include(m => m.Attendees)
                    //                       .ThenInclude(a => a.User)
                    //                       .Where(m => m.Attendees.Where(a => a.User!=null && a.User.UserId == Id).Any())
                    //                       .ToList();

                    //var attendees = dBContext.Attendees.Where(a => a.User.UserId == Id);

                    var attendeeMeetings = dBContext.Meetings
                                                    .Join(dBContext.Attendees,
                                                            m => m.MeetingId,
                                                            a => a.Meeting.MeetingId,
                                                            (m, a) => new MeetingsListVM
                                                            {
                                                                Subject = m.Subject,
                                                                Agenda = m.Agenda,
                                                                Attendees = string.Join(';', m.Attendees.Select(x => x.User.UserName).ToList()),
                                                                MeetingDate = m.Date
                                                            })
                                                            .ToList();
                                                     



                    //.ThenInclude(u => u.ch)
                    //.Include(m => m.Attendees.Select(a => a.User))
                    //.Where(m => m.Attendees.Where(a => a.User.UserId == Id).Any())
                    //.ToList();
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

                    //var userMeetingsVM = _mapper.Map<List<Attendee>, List<AttendeeVM>>(userMeetings);

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


            if (meetingVM != null && meetingVM.MeetingId == 0)
            {
                using (MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {

                    var meeting = _mapper.Map<Meeting>(meetingVM);

                    var query = dBContext.Meetings.Add(meeting);
                    dBContext.SaveChanges();

                    var addedMeetingDetails = dBContext.Meetings.Where(m => m.Subject == meeting.Subject).First();
                    int newAddedMeetingId = addedMeetingDetails.MeetingId;

                    //var assignUserId = dBContext.Attendees
                    //                            Where(a => a.Meeting.MeetingId == newAddedMeetingId);


                    return newAddedMeetingId;
                }
            }

            // logic for updating meeting
            else if (meetingVM != null && meetingVM.MeetingId > 0)
            {
                using (MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {
                    var editedMeeting = _mapper.Map<Meeting>(meetingVM);
                    var updateMeeting = dBContext.Meetings.Update(editedMeeting);
                    dBContext.SaveChanges();
                    return meetingVM.MeetingId;
                }
            }
            else
            {
                return 0;
            }
        }

        public MeetingVM GetMeeting(int meetingId)
        {
            if (meetingId != 0)
            {
                using (MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {
                    var toEditMeeting = dBContext.Meetings.Where(m => m.MeetingId == meetingId).First();

                    MeetingVM meetingVM = _mapper.Map<MeetingVM>(toEditMeeting);

                    return meetingVM;
                }
            }
            else
            {
                return new MeetingVM();
            }
        }

        public int RemoveMeeting(int meetingId)
        {
            if (meetingId != 0)
            {
                using (MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {
                    var meetingToRemove = dBContext.Meetings.Where(m => m.MeetingId == meetingId).First();
                    var removedMeeting = dBContext.Meetings.Remove(meetingToRemove);
                    dBContext.SaveChanges();
                    return meetingId;
                }
            }
            else
            {
                return 0;
            }

        }
    }
}
