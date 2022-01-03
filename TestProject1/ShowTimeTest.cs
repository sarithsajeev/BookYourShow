using BookYourShow.Controllers;
using BookYourShow.MockData;
using BookYourShow.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using BookYourShow.Models;
using BookYourShow.ViewModel;

namespace TestProject1
{
    public class ShowTimeTest
    {
        [Fact]
        public async void GetAllTest()
        {
            //arrange
            var mockRepo = new Mock<IShowTimeRepo>();
            mockRepo.Setup(n => n.GetShowTime()).Returns(MockData.GetAllShowtime());
           
            var controller = new ShowTimeController(mockRepo.Object);
            //act
            var result = await controller.GetShowTime();
            //assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async void GetShowTimeByIdTest()
        {
            //arrange
            var mRepo = MockData.GetShowTimeByIdMock();
            var controller = new ShowTimeController(mRepo.Object);

            //act
            var result = await controller.GetShowTimeById(1);
            var invalid = await controller.GetShowTimeById(100);



            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<OkObjectResult>(invalid);



        }

        [Fact]
        public async void AddShowTimeTest()
        {
            //arrange
            var mRepo = MockData.AddShowTimeMock();
            var controller = new ShowTimeController(mRepo.Object);
            var _showtime = new ShowTime()
            {
                ShowTimeId = 10,
                MovieId = 1,
                TheatreId = 1,
                ShowTimeStart = new DateTime(2021, 01, 01),
               
            };
            //act
            var result = await controller.AddShowTime(_showtime);

            //assert
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public async void UpdateShowtimeTest()
        {
            //arrange
            var mRepo = MockData.UpdateShowTimeMock();
            var controller = new ShowTimeController(mRepo.Object);
            var _showtime = new ShowTime()
            {
                ShowTimeId = 10,
                MovieId = 1,
                TheatreId = 1,
                ShowTimeStart = new DateTime(2021, 01, 01),

            };



            //act
            var result = await controller.UpdateShowTime(_showtime);



            //assert
            Assert.IsType<OkObjectResult>(result);




        }


    }
}
