using BookYourShow.Api.Controllers;
using BookYourShow.Api.Repository;
using BookYourShow.Api.Test.MockData;
using BookYourShow.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace BookYourShow.Api.Test
{
    public class UserUnitTest
    {
        [Fact]
        public async void GetAllTest()
        {

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(n => n.GetUsers()).Returns(UserMockData.GetUserDetails);
            
            var controller = new UserController(mockRepo.Object);
            var result = await controller.GetUsers();
            
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void AddUserTest()
        {
            
            var mRepo = UserMockData.AddUserMock();
            var controller = new UserController(mRepo.Object);
            var _lead = new Users()
            {
                UserId = 104,
                UserName = "Test2",
                Email = "Test2@gmail.com",
                Password = "Test2@123",
                ContactNumber = 9988667544
            };

            var result = await controller.AddUser(_lead);

            Assert.IsType<OkObjectResult>(result);


        }
    }
}
