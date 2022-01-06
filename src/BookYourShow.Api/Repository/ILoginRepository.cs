using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public interface ILoginRepository
    {
        public Users validateUser(string username, string password);
        public string GenerateJSONWebToken(Users users);
        public Users AuthenticateUser(string userName, string password);
    }
}
