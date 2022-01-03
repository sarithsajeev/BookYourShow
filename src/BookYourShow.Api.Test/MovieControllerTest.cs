using BookYourShow.Api.Controllers;
using BookYourShow.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using BookYourShow.Api.Test.MockData;
using Moq;
using System;
using Xunit;
using BookYourShow.Models;

namespace BookYourShow.Api.Test
{
    public class MovieControllerTest
    {

        #region GetMoviesTest   
        [Fact]
        public async void GetMoviesTest()
        {
            //arrange
            var mockRepo = new Mock<IMovieRepository>();
            mockRepo.Setup(n => n.GetAllMovies()).Returns(MockData.MoviesMockData.GetAllMovies());
            var controller = new MoviesController(mockRepo.Object);
            //act
            var result = await controller.GetAllMovies();
            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        #endregion
        #region GetByIdTest
        [Fact]
        public async void GetMovieByIdTest()
        {
            //arrange
            var mRepo = MockData.MoviesMockData.GetMovieByIdTest();
            var controller = new MoviesController(mRepo.Object);
            //act
            var result = await controller.GetMovieById(12);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void GetMovieByIdTest_Returns_NotFound()
        {
            //arrange
            var mRepo = MockData.MoviesMockData.GetMovieByIdTest();
            var controller = new MoviesController(mRepo.Object);
            //act
            var result = await controller.GetMovieById(188);
            //assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result);
        }

        #endregion
        #region AddMovieTest
        [Fact]
        public async void AddMovieTest()
        {
            //arrange
            var mRepo = MockData.MoviesMockData.AddMovieTest();
            var controller = new MoviesController(mRepo.Object);
            var _lead = new Movies()
            {
                MovieId = 18,
                MovieTitle = "Inception",
                MovieDesc = "The Inception Movie",
                MovieRelease = DateTime.Parse("11-12-2017"),
                LangId = 1,
                GenreId = 2,
                OfferId = 1,
                IsActive = true
            };
            //act
            var result = await controller.AddMovie(_lead);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }


        #endregion
        #region UpdateMovieTest
        [Fact]
        public async void UpdateMovieTest()
        {
            //arrange
            var mRepo = MockData.MoviesMockData.UpdateMovieMock();
            var controller = new MoviesController(mRepo.Object);
            var _lead = new Movies()
            {
                MovieId = 14,
                MovieTitle = "The Martian III",
                MovieDesc = "The Martian III Movie",
                MovieRelease = DateTime.Parse("11-12-2017"),
                LangId = 1,
                GenreId = 2,
                OfferId = 1,
                IsActive = true
            };
            //act
            var result = await controller.UpdateMovie(_lead);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        #endregion
        #region DeleteTest
        [Fact]
        public async void DeleteMovieTest()
        {
            //arrange
            var mRepo = MockData.MoviesMockData.DeleteMovieMock();
            var controller = new MoviesController(mRepo.Object);
            //act
            var result = await controller.DeleteMovie(14);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void Delete_ReturnsNotFoundResult()
        {
            //arrange
            var mRepo = MockData.MoviesMockData.DeleteMovieMock();
            var controller = new MoviesController(mRepo.Object);
            //act
            var result = await controller.DeleteMovie(19);
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result);
        }
        #endregion

    }
}
