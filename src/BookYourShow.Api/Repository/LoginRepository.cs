using BookYourShow.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public class LoginRepository:ILoginRepository
    {
        BookYourShowContext _db;
        public IConfiguration _config;
        public LoginRepository(IConfiguration config, BookYourShowContext db)
        {
            _config = config;
            _db = db;
        }

        public string GenerateJSONWebToken(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Users AuthenticateUser(string userName, string password)
        {
            Users dbuser =validateUser(userName, password);
            if (dbuser != null)
            {
                return dbuser;
            }
            return null;
        }


        public Users validateUser(string username, string password)
        {
            if (_db != null)
            {
                Users dbuser = _db.Users.FirstOrDefault(em => em.UserName == username && em.Password == password);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }

            return null;
        }

    }
}
