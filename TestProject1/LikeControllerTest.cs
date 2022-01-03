using BookYourShow.Controllers;
using BookYourShow.MockData;
using BookYourShow.Models;
using BookYourShow.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace TestProject1
{
    public class LikeControllerTest
    {
        [Fact]
        public async void IndexUnitTest()
        {
            //arrange
            var mockRepo = new Mock<ILikeRepo>();
            mockRepo.Setup(n => n.GetLike()).Returns(MockData.GetLike());
            var controller = new LikeController(mockRepo.Object);
            
            //act
            var result = await controller.GetLike();
            
            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void AddLikeTest()
        {
            //arrange
            var mRepo = MockData.AddLikeMock();
            var controller = new LikeController(mRepo.Object);
            var _lead = new Likes()
            {
                LikeId = 5,
                MovieId = 7,
                UserId = 1,
                IsActive = true
            };

            //act
            var result = await controller.AddLike(_lead);

            //assert
            Assert.IsType<OkObjectResult>(result);
            

        }

        [Fact]
        public async void GetLikesByIdTest()
        {
            //arrange
            var mRepo = MockData.GetLikeByIdMock();
            var controller = new LikeController(mRepo.Object);
       
            //act
            var result = await controller.GetLikeById(5);

            //assert
            Assert.IsType<OkObjectResult>(result);
            

        }

        [Fact]
        public async void UpdateLikeTest()
        {
            //arrange
            var mRepo = MockData.UpdateLikeMock();
            var controller = new LikeController(mRepo.Object);
            var _lead = new Likes()
            {
                LikeId = 5,
                MovieId = 7,
                UserId = 1,
                IsActive = true
            };

            //act
            var result = await controller.UpdateLike(_lead);

            //assert
            Assert.IsType<OkObjectResult>(result);

        }


    }
}
