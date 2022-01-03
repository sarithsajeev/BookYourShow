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
    public class LanguageControllerTest
    {
        [Fact]
        public async void GetLanguagesTest()
        {
            //arrange
            var mockRepo = new Mock<ILanguageRepository>();
            mockRepo.Setup(n => n.GetLanguages()).Returns(MockData.MoviesMockData.GetLanguages());
            var controller = new LanguagesController(mockRepo.Object);
            //act
            var result = await controller.GetLanguages();
            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void AddLanguageTest()
        {
            //arrange
            var mRepo = MockData.MoviesMockData.AddLanguageTest();
            var controller = new LanguagesController(mRepo.Object);
            var _lead = new Languages()
            {
                LangId = 5,
                Language = "French"
            };
            //act
            var result = await controller.AddLanguage(_lead);
            //assert
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public async void DeleteLanguageTest()
        {
            //arrange
            var mRepo = MockData.MoviesMockData.DeleteLanguageMock();
            var controller = new LanguagesController(mRepo.Object);
            //act
            var result = await controller.DeleteLanguage(6);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void DeleteLanguageTest_Returns_NotFound()
        {
            //arrange
            var mRepo = MockData.MoviesMockData.DeleteLanguageMock();
            var controller = new LanguagesController(mRepo.Object);
            //act
            var result = await controller.DeleteLanguage(15);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
