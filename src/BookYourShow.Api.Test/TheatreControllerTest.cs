using BookYourShow.Models;
using BookYourShowAPI.Controllers;
using BookYourShow.Api.Test.MockData;
using BookYourShowAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace BookYourShowTest
{
    public class TheatreControllerTest
    {
        [Fact]
        public async void GetTheatreTest()
        {
            //arrange
            var mockRepo = new Mock<ITheatreRepo>();
            mockRepo.Setup(n => n.GetTheatre()).Returns(MockData.GetTheatre());
            var controller = new TheatreController(mockRepo.Object);

            //act
            var result = await controller.GetTheatre();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetTheatreByIdTest()
        {
            //arrange
            var mRepo = MockData.GetTheatreByIdMock();
            var controller = new TheatreController(mRepo.Object);

            //act
            var result = await controller.GetTheatreById(1);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void AddTheatreTest()
        {
            //arrange
            var mRepo = MockData.AddTheatreRepoMock();
            var controller = new TheatreController(mRepo.Object);
            var _theatre = new Theatre()
            {
                TheatreId = 12,
                TheatreName = "BMT Ciniplex",
                Location = "Vijayanagar",
                CityId = 2,
                IsActive = true
            };
            //act
            var result = await controller.AddTheatre(_theatre);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void UpdateTheatreTest()
        {
            //arrange
            var mRepo = MockData.UpdateTheatreMock();
            var controller = new TheatreController(mRepo.Object);
            var _theatre = new Theatre()
            {
                TheatreId = 12,
                TheatreName = "BMT Ciniplex",
                Location = "Vijayanagar",
                CityId = 2,
                IsActive = true
            };

            //act
            var result = await controller.UpdateTheatre(_theatre);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}

