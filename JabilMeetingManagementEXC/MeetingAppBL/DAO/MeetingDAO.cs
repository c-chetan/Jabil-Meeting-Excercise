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

                    var attendee = dBContext.Attendees.Include(a => a.User)
                                                      .Where(a => a.User.UserId == Id && a.Meeting.Date >= DateTime.Now);
                                                      

                    var attendeeMeetings = dBContext.Meetings
                                                    .Join(attendee,
                                                            m => m.MeetingId,
                                                            a => a.Meeting.MeetingId,
                                                            (m, a) => new MeetingsListVM
                                                            {
                                                                MeetingId = m.MeetingId,
                                                                Subject = m.Subject,
                                                                Agenda = m.Agenda,
                                                                AttendeesNames = string.Join("; ", m.Attendees.Select(x => x.User.DisplayName)
                                                                                                        .Distinct().ToList()),
                                                                MeetingDate = m.Date
                                                            }).Distinct()
                                                            .ToList();

                    return attendeeMeetings;
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
                    return newAddedMeetingId;
                }
            }

            // logic for updating meeting
            else if (meetingVM != null && meetingVM.MeetingId > 0)
            {
                using (MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {   
                    var removeExisingAttendees = dBContext.Attendees
                                                            .Where(a => a.Meeting.MeetingId == meetingVM.MeetingId)
                                                            .ToList();
                    dBContext.Attendees.RemoveRange(removeExisingAttendees);
                    dBContext.SaveChanges();

                    var editedMeeting = _mapper.Map<Meeting>(meetingVM);

                    editedMeeting.Attendees.ForEach(a => {
                        a.MeetingId = meetingVM.MeetingId;
                        //a.Meeting = null;
                        a.AttendeeId = 0;
                    });
                    dBContext.Meetings.Update(editedMeeting);
                    dBContext.Attendees.AddRange(editedMeeting.Attendees);
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
                    /*
                    var meetingAttendees = dBContext.Attendees
                                                        .Include(a => a.User)
                                                        //.Where(a => a.IsMeetingOwner == false)
                                                        .Where(a => a.MeetingId == meetingId).ToList();
                    */

                    var toEditMeeting = dBContext.Meetings
                                            .Where(m => m.MeetingId == meetingId)
                                            .First();

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
