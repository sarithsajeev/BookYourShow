using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public interface IUserRepository
    {
        Task<List<Users>> GetUsers();

        //add user
        Task<int> AddUser(Users user);
    }
}
