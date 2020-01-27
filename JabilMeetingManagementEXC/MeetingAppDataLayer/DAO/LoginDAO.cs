using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MeetingAppDataLayer.Models;
using MeetingAppDataLayer.DBContext;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MeetingAppDataLayer.DAO
{
    public class LoginDAO
    {
        private readonly AppSettings appSettings;
        public LoginDAO() 
        {
            appSettings = new AppSettings();
        }

        public string UserAuthenticate(User user)
        {
            string token;

            if(user!=null && user.UserName.Length > 0 && user.Password.Length > 0)
            {
                using (MeetDBContext dbContext = new MeetDBContext(MeetDBContext.optionsBld.dbOptions))
                {
                    
                    var authenticatedUserDetails = dbContext.Set<User>()
                                                    .Where(x => x.UserName == user.UserName && x.Password == user.Password)
                                                    .FirstOrDefault();                                           

                    if(authenticatedUserDetails!=null && authenticatedUserDetails.UserName.Length > 0 && authenticatedUserDetails.Password.Length > 0)
                    {
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
                        token = tokenHandler.WriteToken(securityToken);
                        if(token!=null && token.Length > 0)
                        {
                            return token;
                        }
                        else
                        {
                            return token = "";
                        }
                    }
                }
            }
            return "";
        }
    }
}
