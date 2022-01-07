using BookYourShow.Api.Repository;
using BookYourShow.Controllers;
using BookYourShow.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookYourShow.test
{
    public class SeatControllerTest
    {
        
      [Fact]
      public async Task SeatUnitTestWhenNotFound()
        {
            int id = 1;
            var mockRepo = new Mock<ISeatRepository>();
            var controller = new SeatController(mockRepo.Object);



            var result = await controller.GetSeats(id);



            Assert.IsType<NotFoundResult>(result);

        }
        [Fact]
        public async Task SeatUnitTestForGetAllSeats()
        {
            //arrange
            int id = 1;
            var mockRepo = new Mock<ISeatRepository>();
            mockRepo.Setup(n => n.GetSeats(id)).Returns(Task.FromResult(GetTestSeats().FindAll(s=>s.TheatreId==id)));
            var controller = new SeatController(mockRepo.Object);

            //act
            var result = await controller.GetSeats(id);

            //assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<List<Seats>>(okResult.Value);
            var seat = model.Count();
           
           // Assert.;
            Assert.Equal(1,seat);
          
           
        }
        [Fact]
        public async Task SeatUnitTestById()
        {
            //arrange
            int tid = 1;
            int id = 1;
            var mockRepo = new Mock<ISeatRepository>();
            mockRepo.Setup(n => n.GetSeatById(id,tid)).Returns(Task.FromResult(GetTestSeats().FirstOrDefault(s => s.TheatreId == tid && s.SeatId==id)));
            var controller = new SeatController(mockRepo.Object);

            //act
            var result = await controller.GetSeatById(id,tid);

            //assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<Seats>(okResult.Value);
            


        }

        [Fact]
        public async Task SeatUnitTestForAddSeat()
        {
            //arrange
            int id = 1;
            var seat = new Seats();
            int SeatId = 3;
            string Row = "A";
            int Number = 2;
           // int TheatreId = 1;
            bool IsActive = true;
            bool Status = true;
            var testSeats = GetTestSeats();
            //var s = new Seats();

            var newSeat = new Seats()
            {
                SeatId = SeatId,
                Row = Row,
                Number = Number,
                TheatreId = id,
                IsActive = IsActive,
                Status = Status

            };
            var mockRepo = new Mock<ISeatRepository>();
            mockRepo.Setup(repo => repo.AddSeat(newSeat,id))
                .ReturnsAsync(newSeat.SeatId);
            var controller = new SeatController(mockRepo.Object);


          


            //act
            var result = await controller.AddSeat(newSeat, id);

            var okResult = Assert.IsType<OkObjectResult>(result);
           
           



        }
        [Fact]
        public async void UpdateSeatTest()
        {
            int id = 1;
            var s = new Seats();
            var seat = new Seats()
            {
                SeatId = 1,
                Row = "A",
                Number = 10,
                TheatreId = 1,
                IsActive = true,
                Status = true
            };

            //Valid Input Id
            var mockRepo = new Mock<ISeatRepository>();
            mockRepo.Setup(repo => repo.UpdateSeat(seat,id));
            var controller = new SeatController(mockRepo.Object);

            var result = await controller.UpdateSeat(seat,id);

           
            Assert.IsType<OkResult>(result);
        }

        private List<Seats> GetTestSeats()
        {
            var _seats = new List<Seats>();
            _seats.Add(new Seats()
            {
                SeatId = 1,
                Row = "A",
                Number = 1,
                TheatreId = 1,
                IsActive = true,
                Status = true

            });
            _seats.Add(new Seats()
            {
                SeatId = 2,
                Row = "A",
                Number = 2,
                TheatreId = 2,
                IsActive = true,
                Status = true
            });
            return _seats;
        }
    }
}
