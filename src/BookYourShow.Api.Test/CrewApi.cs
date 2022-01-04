using BookYourShow.Api.Repository;
using System;
using Xunit;
using Moq;
using BookYourShow.MockData;
using BookYourShow.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using BookYourShow.Models;

namespace BookYourShow.Api.Test
{
    public class CrewApi
    {
        [Fact]

        public async void GetMembers_test()
        {
            //arrange
            var mockRepo = new Mock<ICrewRepo>();
            mockRepo.Setup(n => n.GetCrewMembers()).Returns(CrewMockData.GetMembers_Mock());
            //act
            var controller = new CrewController(mockRepo.Object);
            var result = await controller.GetCrewMembers();
            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void AddMembers_test()
        {
            //arrange
            var mRepo = CrewMockData.AddMembers_Mock();
            var controller = new CrewController(mRepo.Object);
            var _member = new Crew()
            {
                MemberId=16,
                MemberName="John Philip",
                IsActive = true
            };


            //act
            var result = await controller.AddCrewMember(_member);


            //assert
            Assert.IsType<OkObjectResult>(result);
           


        }

        [Fact]
        public async void UpdateCrew_Test()
        {
            //arrange
            var mRepo = CrewMockData.UpdateCrewMember_Mock();
            var controller = new CrewController(mRepo.Object);
            var _member = new Crew()
            {
                MemberId=3,
                MemberName="Jomon T John",
                IsActive = true
            };

            //act
            var result = await controller.UpdateCrew(_member);

            //assert
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async void DeleteCrew_Test()
        {
            //arrange
            var mRepo = CrewMockData.DeleteCrew_Mock();
            var controller = new CrewController(mRepo.Object);
            //act
            var result = await controller.DeleteCrewMember(9);
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async void DeleteCrew_ReturnsNotFound()
        {
            //arrange
            var mRepo = CrewMockData.DeleteCrew_Mock();
            var controller = new CrewController(mRepo.Object);
            //act
            var result = await controller.DeleteCrewMember(25);
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result);
        }

        [Fact]
        public async void GetCrewById_Test()
        {
            //arrange
            var mRepo = CrewMockData.GetCrewMemberById_Mock();
            var controller = new CrewController(mRepo.Object);
            //act
            var result = await controller.GetCrewMember(3);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
