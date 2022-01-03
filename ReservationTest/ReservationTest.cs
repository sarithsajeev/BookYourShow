using BookYourShow.Controllers;
using BookYourShow.MockData;
using BookYourShow.Models;
using BookYourShow.Repository;
using BookYourShow.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ReservationTest
{
    public class ReservationTest
    {
        [Fact]
        public async void GetReservationTest()
        {
            var mockRepo = new Mock<IReservationRepo>();
            mockRepo.Setup(n => n.AllReservations()).Returns(ReservationMockData.GetAllReservations());
            var controller = new ReservationController(mockRepo.Object);

            var result = await controller.GetReservations();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<List<ReservationModel>>(okResult.Value);
            Assert.Equal(2, model.Count);
        }


        [Fact]
        public async void GetReservationFailTest()
        {
            var mockRepo = new Mock<IReservationRepo>();
            var controller = new ReservationController(mockRepo.Object);

            var result = await controller.GetReservations();

            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public async void AddReservationTest()
        {
            //arrange
            var mRepo = ReservationMockData.AddReservationRepoMock();
            var controller = new ReservationController(mRepo.Object);
            var _lead = new Reservation()
            {
                ReservationId = 3,
                ShowTimeId = 1,
                UserId = 1,
                TicketCount = 3,
                PaymentInfo = "600 paid"
            };

            //act
            var result = await controller.AddReservation(_lead);

            //assert
            Assert.IsType<OkObjectResult>(result);
            /*Assert.Equal("Index", redirectToActionResult.ToString());*/
            /*Assert.Null(redirectToActionResult.ControllerName);*/

        }


        [Fact]
        public async void AddReservationFailTest()
        {
            //arrange
            var mRepo = new Mock<IReservationRepo>();
            var controller = new ReservationController(mRepo.Object);
            var _lead = new Reservation()
            {
                ReservationId = 3,
                ShowTimeId = 1,
                UserId = 1,
                TicketCount = 3,
                PaymentInfo = "600 paid"
            };

            //act
            var result = await controller.AddReservation(_lead);

            //assert
            Assert.IsType<BadRequestResult>(result);
            /*Assert.Equal("Index", redirectToActionResult.ToString());*/
            /*Assert.Null(redirectToActionResult.ControllerName);*/

        }

        [Fact]
        public async void UpdateSeatTest()
        {
            var mRepo = ReservationMockData.UpdateReservationRepoMock();
            var controller = new ReservationController(mRepo.Object);
            var seats = new SeatsView()
            {
                Seats = new int[] { 1, 2, 3 },
                ReservationId = 1
            };

            var result = await controller.ReserveSeat(seats);

            Assert.IsType<OkResult>(result);
        }


        [Fact]
        public async void UpdateSeatFailTest()
        {
            var mRepo = new Mock<IReservationRepo>();
            var controller = new ReservationController(mRepo.Object);
            var seats = new SeatsView()
            {
                Seats = new int[] { 1, 2, 3 },
                ReservationId = 1
            };

            var result = await controller.ReserveSeat(seats);

            Assert.IsType<BadRequestResult>(result);
        }


        [Theory]
        [InlineData(1)]
        public async void DeleteReservationTest(int id)
        {
            var reserveId = id;
            var mRepo = ReservationMockData.DeleteReservationRepoMock();
            var controller = new ReservationController(mRepo.Object);

            var result = await controller.DeleteReservation(reserveId);

            Assert.IsType<OkResult>(result);
        }


        [Theory]
        [InlineData(1)]
        public async void DeleteReservationFailTest(int id)
        {
            var reserveId = id;
            var mRepo = new Mock<IReservationRepo>();
            var controller = new ReservationController(mRepo.Object);

            var result = await controller.DeleteReservation(reserveId);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
