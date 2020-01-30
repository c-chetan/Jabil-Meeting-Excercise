using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using MeetingAppDataLayer.Models;
using MeetingAppDataLayer.DAO;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JabilMeetingManagementEXC.ApiControllers
{

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
        public IActionResult AuthenticateUser([FromBody]User user)
        {
            string generatedToken;

            if(user != null && user.UserName.Length > 0 && user.Password.Length > 0)
            { 
                LoginDAO loginDao = new LoginDAO();
                if(loginDao !=null)
                {
                    generatedToken = loginDao.UserAuthenticate(user);

                    return Ok(new { generatedToken });
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
