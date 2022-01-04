using BookYourShow.Api.Controllers;
using BookYourShow.Models;
using BookYourShow.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookYourShow.Api.Test
{
    public class GenreControllerTest
    {
        [Fact]
        public async void GetGenresTest()
        {
            //arrange
            var mockRepo = new Mock<IGenreRepository>();
            mockRepo.Setup(n => n.GetGenres()).Returns(MockData.GenresMockData.GetGenres());
            var controller = new GenresController(mockRepo.Object);
            //act
            var result = await controller.GetGenres();
            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void AddGenreTest()
        {
            //arrange
            var mRepo = MockData.GenresMockData.AddGenreTest();
            var controller = new GenresController(mRepo.Object);
            var _lead = new Genres()
            {
                GenreId = 5,
                Genre = "Sci-Fi"
            };
            //act
            var result = await controller.AddGenre(_lead);
            //assert
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public async void DeleteGentreTest()
        {
            //arrange
            var mRepo = MockData.GenresMockData.DeleteGenreMock();
            var controller = new GenresController(mRepo.Object);
            //act
            var result = await controller.DeleteGenre(5);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void DeleteGentreTest_Returns_NotFound()
        {
            //arrange
            var mRepo = MockData.GenresMockData.DeleteGenreMock();
            var controller = new GenresController(mRepo.Object);
            //act
            var result = await controller.DeleteGenre(15);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
