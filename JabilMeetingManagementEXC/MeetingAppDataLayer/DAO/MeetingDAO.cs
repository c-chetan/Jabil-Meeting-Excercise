using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using MeetingAppDataLayer.Models;
using MeetingAppDataLayer.DBContext;
using Microsoft.EntityFrameworkCore;

namespace MeetingAppDataLayer.DAO
{
    public class MeetingDAO
    {
        private readonly AppSettings appSettings;

        public MeetingDAO()
        {
            appSettings = new AppSettings();
        }

        public IEnumerable<Attendee> GetMeetingsList(int Id)
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

                    return userMeetings;
                }
            }
            else
            {
                return new List<Attendee>();
            }
        }
        
    }
}
