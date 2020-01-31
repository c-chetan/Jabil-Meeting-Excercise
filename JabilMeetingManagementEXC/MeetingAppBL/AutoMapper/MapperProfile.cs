using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingAppDataLayer.Models;
using MeetingAppBL.ViewModel;

namespace MeetingAppBL.AutoMapper
{
    public class MapperProfile: Profile
    {

        public MapperProfile()
        {
            CreateMap<User, UserVM>();
        }
    }
}
