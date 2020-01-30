using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingAppDataLayer.Models;
using JabilMeetingManagementEXC.ViewModel;

namespace JabilMeetingManagementEXC.AutoMapper
{
    public class MapperProfile: Profile
    {

        public MapperProfile()
        {
            CreateMap<User, UserVM>();
        }
    }
}
