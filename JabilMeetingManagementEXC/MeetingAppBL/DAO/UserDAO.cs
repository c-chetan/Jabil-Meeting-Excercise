using System.Linq;
using System.Collections.Generic;
using System.Text;
using MeetingAppBL.ViewModel;
using MeetingAppDataLayer.DBContext;
using MeetingAppDataLayer.Models;
using MeetingAppDataLayer;
using AutoMapper;

namespace MeetingAppBL.DAO
{
    public class UserDAO
    {
        private readonly AppSettings appSettings;
        private readonly IMapper _mapper;
        
        public UserDAO(IMapper mapper)
        {
            appSettings = new AppSettings();
            _mapper = mapper;
        }

        public List<UserVM> GetUsers()
        {
            using (MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
            {
                var users = dBContext.Users
                                .Select(u => new UserVM {
                                    UserId = u.UserId,
                                    UserName = u.UserName,
                                })
                                .ToList();

                //List<UserVM> usersList = _mapper.Map<List<User>,List<UserVM>>(users);

                return users;
            }
        }

        public UserVM GetUser(int UserId)
        {
            if(UserId!= 0)
            {
                using (MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {
                    var user = dBContext.Users.Find(UserId);

                    var userVM = _mapper.Map<UserVM>(user);
                    return userVM;
                }
            }
            else
            {
                return new UserVM();
            }
        }

        public int AddUser(UserVM userVM)
        {
            if(userVM!=null && userVM.UserId == 0)
            {
                using (MeetDBContext dBContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {


                    var user = _mapper.Map<User>(userVM);

                    var addUser = dBContext.Users.Add(user);
                    dBContext.SaveChanges();

                    var addedUserDetails = dBContext.Users.Where(u => u.UserName == user.UserName).First();

                    int newAddedUserId = addedUserDetails.UserId;

                    return newAddedUserId;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
