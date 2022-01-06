using BookYourShow.Repository;
using BookYourShow.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;
using BookYourShow.Models;
using BookYourShow.ViewModel;
using System.Collections.Generic;

namespace TicketsTest
{
    public class ViewTicketsTest
    {
        [Theory]
        [InlineData(1,100)]
        public  void GetAllTest(int validId,int invalidId)
        {
            //expected result for not found response
            List<TicketViewModel> emptyResponse = new List<TicketViewModel>();
            
            //expected result for ok response
            var expectedResponse = new List<TicketViewModel>
            {
                   new TicketViewModel()
                   {
                     UserName= "Surabhi",
                     ContactNumber= 7560954031,
                     Movie= "The Flower of evil",
                     TheatreName="PVR",
                     SeatNumber= 101,
                     TicketCount= 3
                   },

                   new TicketViewModel()
                   {
                     UserName= "Surabhi",
                     ContactNumber= 7560954031,
                     Movie= "The Flower of evil",
                     TheatreName="PVR",
                     SeatNumber= 102,
                     TicketCount= 3
                   },
                   
                   new TicketViewModel()
                   {
                     UserName= "Surabhi",
                     ContactNumber= 7560954031,
                     Movie= "The Flower of evil",
                     TheatreName="PVR",
                     SeatNumber= 103,
                     TicketCount= 3
                   }
            };
            
            //for ok response
            //arrange
            var mockRepo = new Mock<ITicketsRepo>();
            mockRepo.Setup(n => n.ViewTickets(validId)).ReturnsAsync(expectedResponse);
            var controller1=new TicketsController(mockRepo.Object);

            //act
            var validResult = controller1.ViewTickets(validId);

            //assert
            var response = Assert.IsType<OkObjectResult>(validResult.Result);
            var tickets= Assert.IsType<List<TicketViewModel>>(response.Value);
            Assert.Equal(3,tickets.Count);
            Assert.Equal(expectedResponse[0].UserName, tickets[0].UserName);


            //for notfound response
            //arrange
            mockRepo.Setup(n => n.ViewTickets(invalidId)).ReturnsAsync(emptyResponse);
            var controller2 = new TicketsController(mockRepo.Object);

            //act
            var invalidResult = controller2.ViewTickets(invalidId);

            //assert
            Assert.IsType<NotFoundResult>(invalidResult.Result);
        }
    }
}
