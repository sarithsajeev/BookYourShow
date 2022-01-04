using BookYourShow.Api.Controllers;
using BookYourShow.Api.Repository;
using BookYourShow.Api.Test.MockData;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using BookYourShow.Models;

namespace  BookYourShow.Api.Test

{
    public class ActorsApi
    {
        [Fact]
        public async void GetActors_Test()
        {
            //arrange
            var mockRepo = new Mock<IActorRepo>();
            mockRepo.Setup(n => n.GetActors()).Returns(ActorsMockData.GetActors_Mock());
          
            //act
            var controller = new ActorsController(mockRepo.Object);
            var result = await controller.GetActors();
            //assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async void AddActor_test()
        {
            //arrange
            var mRepo = ActorsMockData.AddActor_Mock();
            var controller = new ActorsController(mRepo.Object);
            var _actor = new Actors()
            {
                ActorId=19,
                ActorName="John Abraham",
                IsActive = true
            };


            //act
            var result = await controller.AddActor(_actor);


            //assert
            Assert.IsType<OkObjectResult>(result);



        }

        [Fact]
        public async void UpdateActor_Test()
        {
            //arrange
            var mRepo = ActorsMockData.UpdateActor_Mock();
            var controller = new ActorsController(mRepo.Object);
            var _actor = new Actors()
            {
                ActorId = 12,
                ActorName = "Tom Hiddleston",
                IsActive = true
            };

            //act
            var result = await controller.UpdateActor(_actor);

            //assert
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async void DeleteActor_Test()
        {
            //arrange
            var mRepo = ActorsMockData.DeleteActor_Mock();
            var controller = new ActorsController(mRepo.Object);
            //act
            var result = await controller.DeleteActor(13);
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async void DeleteActor_ReturnsNotFound()
        {
            //arrange
            var mRepo = ActorsMockData.DeleteActor_Mock();
            var controller = new ActorsController(mRepo.Object);
            //act
            var result = await controller.DeleteActor(25);
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result);
        }

        [Fact]
        public async void GetActorById_Test()
        {
            //arrange
            var mRepo = ActorsMockData.GetActorById_Mock();
            var controller = new ActorsController(mRepo.Object);
            //act
            var result = await controller.GetActor(12);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }

    }
}
