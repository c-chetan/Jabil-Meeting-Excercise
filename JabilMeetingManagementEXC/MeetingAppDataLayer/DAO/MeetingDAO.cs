using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MeetingAppDataLayer.Models;
using MeetingAppDataLayer.DBContext;

namespace MeetingAppDataLayer.DAO
{
    public class MeetingDAO
    {
        private readonly AppSettings appSettings;

        public MeetingDAO()
        {
            appSettings = new AppSettings();
        }

        public IEnumerable<Meeting> GetMeetingsList(int Id)
        {
            if(Id!=0)
            {
                using(MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {
                    var attendee = dBContext.Set<Attendee>()
                                                    .Where(x => x.User.UserId == Id).FirstOrDefault();

                    var attendeeMeetings = dBContext.Set<Meeting>()
                                                    .Where(x => x.MeetingId == attendee.Meeting.MeetingId).ToList();
                    return attendeeMeetings;
                }
            }
            else
            {
                return new List<Meeting>();
            }
        }
    }
}
