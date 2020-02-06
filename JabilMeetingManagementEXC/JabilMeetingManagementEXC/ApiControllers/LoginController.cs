using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MeetingAppDataLayer.Models;
using MeetingAppBL.DAO;
using MeetingAppBL.ViewModel;
using AutoMapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JabilMeetingManagementEXC.ApiControllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IMapper _mapper;

        public LoginController(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        [HttpPost]
        [Route("authenticate")]
        public IActionResult AuthenticateUser([FromBody]UserVM userVM)
        {

            if(userVM != null && userVM.UserName.Length > 0 && userVM.Password.Length > 0)
            { 
                LoginDAO loginDao = new LoginDAO(_mapper);
                if(loginDao !=null)
                {
                    UserVM authenticatedUser = loginDao.UserAuthenticate(userVM);

                    authenticatedUser.Password = string.Empty;

                    if(authenticatedUser.userToken != "")
                    { 

                        return Ok(new JsonResult(authenticatedUser));
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
            }
            else
            {
                return Ok(new { message = "Invalid Credentials" });
            }
            return BadRequest(new { message = "Bad Request" });

        }
    }
}
