using BookYourShow.Api.Repository;
using BookYourShow.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookYourShow.Api.Test.MockData
{
    public class UserMockData
    {
        public static async Task<List<Users>> GetUserDetails()
        {
            var _users = new List<Users>()
          {
            new Users()
            {
                UserId =101,
                UserName = "Yadhu",
                Email="yadhu@gmail.com",
                Password="yadhu@123",
                ContactNumber=9898767654
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
                    UserId =102,
                    UserName = "Yadhu",
                    Email="yadhu@gmail.com",
                    Password="yadhu@123",
                    ContactNumber=9808767654
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