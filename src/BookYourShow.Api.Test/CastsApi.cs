using BookYourShow.Api.Controllers;
using BookYourShow.Api.Test.MockData;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using BookYourShow.Api.Repository;
using BookYourShow.Models;

namespace BookYourShow.Api.Test
{
    public class CastsApi
    {
        [Fact]
        public async void GetCastByMovieId_Test()
        {
            //arrange
            var mockRepo = new Mock<ICastsRepo>();
            int id = 1;
            mockRepo.Setup(n => n.GetCasts(id)).Returns(CastsMockData.GetCastsByMovieId_Mock());
            //act
            var controller = new CastsController(mockRepo.Object);
            var result = await controller.GetCasts(id);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetCastById_Test()
        {
            //arrange
            var mRepo = CastsMockData.GetCastById_Mock();
            var controller = new CastsController(mRepo.Object);
            //act
            var result = await controller.GetCast(3);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void AddCast_test()
        {
            //arrange
            var mRepo = CastsMockData.AddCast_Mock();
            var controller = new CastsController(mRepo.Object);
            var cast = new Casts()
            {
                CastId = 3,
                ActorId = 12,
                RoleName = "Captain America",
                MovieId = 1
            };
            //act
            var result = await controller.AddCast(cast);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void UpdateCast_Test()
        {
            //arrange
            var mRepo = CastsMockData.UpdateCast_Mock();
            var controller = new CastsController(mRepo.Object);
            var cast = new Casts()
            {
                CastId = 3,
                ActorId = 12,
                RoleName = "Captain America Jr.",
                MovieId = 1
            };
            //act
            var result = await controller.UpdateCast(cast);
            //assert
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async void DeleteCast_Test()
        {
            //arrange
            var mRepo = CastsMockData.DeleteCast_Mock();
            var controller = new CastsController(mRepo.Object);
            //act
            var result = await controller.DeleteCast(3);
            Assert.IsType<OkObjectResult>(result);
        }   
    }
}
