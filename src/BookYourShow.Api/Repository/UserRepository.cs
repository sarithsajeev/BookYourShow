using BookYourShow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public class UserRepository:IUserRepository
    {
        BookYourShowContext db;

        public UserRepository(BookYourShowContext _db)
        {
            db = _db;
        }
        //get all users
        public async Task<List<Users>> GetUsers()
        {
            if (db != null)
            {
                return await db.Users.ToListAsync();
            }
            return null;
        }

        public async Task<int> AddUser(Users user)
        {
            if (db != null)
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync(); 
                return user.UserId;
            }
            return 0;

        }
    }
}
