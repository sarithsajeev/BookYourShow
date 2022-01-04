using BookYourShow.Repository;
using BookYourShow.Controllers;
using BookYourShow.MockData;
using System;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using BookYourShow.Models;

namespace MovieCrewTest
{
    public class MovieCrewApi
    {
        [Fact]
        public async void GetMovieCrewMembers_Test()
        {
            //arrange
            var mockRepo = new Mock<IMovieCrewRepo>();
            int id = 10;
            mockRepo.Setup(n => n.GetCrewMembers(id)).Returns(MovieCrewMockData.GetMovieCrews());
 
            //act
            var controller = new MovieCrewController(mockRepo.Object);
            var result = await controller.GetMovieCrewMembers(id);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async void GetMovieCrewById_Test()
        {
            //arrange
            var mRepo = MovieCrewMockData.GetMovieCrewById_Mock();
            var controller = new MovieCrewController(mRepo.Object);
            //act
            var result = await controller.GetCrewMember(1);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void AddMovieCrew_test()
        {
            //arrange
            var mRepo = MovieCrewMockData.AddMovieCrew_Mock();
            var controller = new MovieCrewController(mRepo.Object);
            var crew = new MovieCrew()
            {
                MovieCrewId = 1,
                MemberId = 10,
                RoleName = "Director",
                MovieId = 1
            };


            //act
            var result = await controller.AddCrewMember(crew);


            //assert
            Assert.IsType<OkObjectResult>(result);



        }

        [Fact]
        public async void UpdateMovieCrew_Test()
        {
            //arrange
            var mRepo = MovieCrewMockData.UpdateMovieCrew_Mock();
            var controller = new MovieCrewController(mRepo.Object);
            var crew = new MovieCrew()
            {
                MovieCrewId = 1,
                MemberId = 10,
                RoleName = "Screenplay",
                MovieId = 1
            };

            //act
            var result = await controller.UpdateCrewMember(crew);

            //assert
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async void DeleteMovieCrew_Test()
        {
            //arrange
            var mRepo = MovieCrewMockData.DeleteMovieCrew_Mock();
            var controller = new MovieCrewController(mRepo.Object);
            //act
            var result = await controller.DeleteCrewMember(2);
            Assert.IsType<OkObjectResult>(result);
        }


    }
}
