﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MeetingAppBL.DAO;
using MeetingAppBL.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JabilMeetingManagementEXC.ApiControllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            if(userId!=0)
            {
                UserDAO userDao = new UserDAO(_mapper);

                UserVM userVM = userDao.GetUser(userId);

                UserVM userDetails = new UserVM()
                {
                    UserId = userVM.UserId,
                    UserName = userVM.UserName,
                    UserCode = userVM.UserCode
                };

                return  Ok(new JsonResult(userDetails));
            }
            else
            {
                return BadRequest();
            }
        }
        

        [HttpGet]
        [Route("users")]
        public IActionResult GetUsers()
        {
            IMapper mappr = _mapper;

            UserDAO userDAO = new UserDAO(mappr);

            List<UserVM> users = userDAO.GetUsers();

            return Ok(new JsonResult(users));
        }

        [HttpPost]
        [Route("add-user")]
        public IActionResult AddUser([FromBody]UserVM userVM)
        {
            IMapper mappr = _mapper;

            if(userVM!=null)
            { 
                UserDAO userDAO = new UserDAO(mappr);

                int userId = userDAO.AddUser(userVM);

                if(userId!=0)
                {
                    return Ok(new JsonResult(userId));
                }
                else
                {
                    return Ok(new JsonResult(new { userId = 0 }));
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
