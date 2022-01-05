using BookYourShow.Controllers;
using BookYourShow.Models;
using BookYourShow.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace BookYourShow.Api.Test
{
    public class CityTestController
    {
        #region GetCitiesTest   
        [Fact]
        public async void GetCitiesTest()
        {
            //arrange
            var mockRepo = new Mock<ICityRepo>();
            mockRepo.Setup(n => n.GetCities()).Returns(MockData.CityMockData.GetAllCities());
            var controller = new CityController(mockRepo.Object);
            //act
            var result = await controller.GetCity();
            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void GetMoviesFailTest()
        {
            var mockRepo = new Mock<ICityRepo>();
            var controller = new CityController(mockRepo.Object);
            var result = await controller.GetCity();
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion

        #region GetByIdTest
        [Fact]
        public async void GetCityByIdTest()
        {
            //arrange
            var mRepo = MockData.CityMockData.GetCityByIdTest();
            var controller = new CityController(mRepo.Object);
            //act
            var result = await controller.GetCityById(12);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void GetMovieByIdTest_Returns_NotFound()
        {
            //arrange
            var mRepo = MockData.CityMockData.GetCityByIdTest();
            var controller = new CityController(mRepo.Object);
            //act
            var result = await controller.GetCityById(188);
            //assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result);
        }

        #endregion

        #region AddCityTest
        [Fact]
        public async void AddCityTest()
        {
            //arrange
            var mRepo = MockData.CityMockData.AddCityTest();
            var controller = new CityController(mRepo.Object);
            var _lead = new City()
            {
                CityId = 16,
                CityName = "Vazhakala",
                Zipcode = "683451",
                State = "Kerala",
                IsActive = true
            };
            //act
            var result = await controller.AddCity(_lead);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void AddMovieFailTest()
        {
            //arrange
            var mRepo = new Mock<ICityRepo>();
            var controller = new CityController(mRepo.Object);
            var _lead = new City()
            {
                CityId = 12,
                CityName = "Vazhakala",
                Zipcode = "683451",
                State = "Kerala",
                IsActive = true
            };

            //act
            var result = await controller.AddCity(_lead);

            //assert
            Assert.IsType<NotFoundResult>(result);
        }

        #endregion


        #region UpdateCityTest
        [Fact]
        public async void UpdateCityTest()
        {
            //arrange
            var mRepo = MockData.CityMockData.UpdateCityMock();
            var controller = new CityController(mRepo.Object);
            var _lead = new City()
            {
                CityId = 12,
                CityName = "Vazhakala",
                Zipcode = "683561",
                State = "Kerala",
                IsActive = true
            };
            //act
            var result = await controller.UpdateCity(_lead);
            //assert
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public async void UpdateCitiesFailTest()
        {
            var mRepo = new Mock<ICityRepo>();
            var controller = new CityController(mRepo.Object);
            var seats = new City()
            {
                CityName = "Vazhakala",
                Zipcode = "683561",
                State = "Kerala",
                IsActive = true
            };

            controller.ModelState.AddModelError("CityId", "CityId is reuired");
            var result = await controller.UpdateCity(seats);

            Assert.IsType<BadRequestResult>(result);
        }
        #endregion

        #region UpdateCityStatusTest
        [Fact]
        public async void UpdateCityStatusTest()
        {
            //arrange
            var mRepo = MockData.CityMockData.UpdateCityStatusMock();
            var controller = new CityController(mRepo.Object);
            var _lead = new City()
            {
                CityId = 12,
                CityName = "Vazhakala",
                Zipcode = "683561",
                State = "Kerala",
                IsActive = true
            };
            //act
            var result = await controller.UpdateCityActiveStatus(12);
            //assert
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public async void UpdateCityStatusFailTest()
        {
            var mRepo = new Mock<ICityRepo>();
            var controller = new CityController(mRepo.Object);
            var seats = new City()
            {
                CityName = "Vazhakala",
                Zipcode = "683561",
                State = "Kerala",
                IsActive = true
            };

            controller.ModelState.AddModelError("CityId", "CityId is reuired");
            var result = await controller.UpdateCityActiveStatus(12);

            Assert.IsType<BadRequestResult>(result);
        }
        #endregion
    }


}
