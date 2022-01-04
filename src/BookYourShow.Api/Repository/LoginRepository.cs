using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public class LoginRepository:ILoginRepository
    {
        BookYourShowContext _db;

        public LoginRepository(BookYourShowContext db)
        {
            _db = db;
        }


        //Validate user 
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
