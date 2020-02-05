using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MeetingAppDataLayer;
using MeetingAppDataLayer.Models;
using MeetingAppDataLayer.DBContext;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MeetingAppBL.ViewModel;
using AutoMapper;

namespace MeetingAppBL.DAO
{
    public class LoginDAO
    {
        private readonly AppSettings appSettings;
        private readonly IMapper _mapper;

        public LoginDAO(IMapper mapper) 
        {
            appSettings = new AppSettings();
            _mapper = mapper;
        }

        public UserVM UserAuthenticate(UserVM user)
        {

            if(user!=null && user.UserName.Length > 0 && user.Password.Length > 0)
            {
                using (MeetDBContext dbContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {
                    
                    var authenticateUser = dbContext.Users
                                                    .Where(x => x.UserName == user.UserName && x.Password == user.Password)
                                                    .FirstOrDefault();                                           

                    if(authenticateUser != null && authenticateUser.UserName.Length > 0 && authenticateUser.Password.Length > 0)
                    {
                        UserVM authenticatedUserDetails = _mapper.Map<UserVM>(authenticateUser);

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim("UserId", authenticatedUserDetails.UserId.ToString())
                            }),
                            Expires = DateTime.UtcNow.AddMinutes(5),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(
                                                                        Encoding.UTF8.GetBytes(
                                                                           appSettings.SecurityKey)), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                        authenticatedUserDetails.userToken = tokenHandler.WriteToken(securityToken);
                        if(authenticatedUserDetails.userToken != null && authenticatedUserDetails.userToken.Length > 0)
                        {
                            return authenticatedUserDetails;
                        }
                    }
                }
            }
            return new UserVM();
        }
    }
}
