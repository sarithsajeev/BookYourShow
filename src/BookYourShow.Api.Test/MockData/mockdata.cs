using BookYourShow.Api.Repository;
using BookYourShow.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookYourShow.Api.Test.MockData
{
    public class mockdata
    {
        public static async Task<List<Users>> GetUserDetails()
        {
            var _users = new List<Users>()
            {
                new Users()
                {
                    UserId = 101,
                    UserName = "Yadhu",
                    Email = "yadhuemofficial@gmail.com",
                    Password = "yadhu@123",
                    ContactNumber =9988776655
                }
            };
            return _users;
        }

        public static Mock<IUserRepository> AddUserMock()
        {
            var users = new List<Users>()
            {
                new Users()
                {
                    UserId= 103,
                    UserName = "Test1",
                    Email ="Test1@gmail.com",
                    Password= "Test1@123",
                    ContactNumber=9988665544
                }
            };
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.AddUser(It.IsAny<Users>())).ReturnsAsync((Users user) =>
            {
                users.Add(user);
                return user.UserId;
            });
            return mockRepo;
        }
    }
}

