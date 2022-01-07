using Moq;
using System;
using Xunit;
using BookYourShow.Api.Repository;
using BookYourShow.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using BookYourShow.Models;
using BookYourShow.Api.Test.MockData;

namespace BookYourShow.Api.Test
{
    public class OfferControllerTest
    {
        [Fact]
        public async void OfferByMovie()
        {
            //arrange
            var mockRepo = new Mock<IOfferRepository>();
            mockRepo.Setup(n => n.OfferByMovie()).Returns(OffersMockData.OfferByMovie());

            //act
            var controller = new OfferController(mockRepo.Object);
            var result = await controller.OfferByMovie();
            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void AddOfferTest()
        {
            //arrange
            var mRepo = OffersMockData.AddOffersTest();
            var controller = new OfferController(mRepo.Object);
            var _lead = new Offers()
            {
                OfferId = 1,
                OfferName = "10%Off",
                OfferDescription = "10% off on final price"
            };



            //act
            var result = await controller.AddOffers(_lead);



            //assert
            Assert.IsType<OkObjectResult>(result);


        }

        #region UpdateOfferTest
        [Fact]
        public async void UpdateMovieTest()
        {
            //arrange
            var mRepo = OffersMockData.UpdateOfferTest();
            var controller = new OfferController(mRepo.Object);
            var _offer = new Offers()
            {
                OfferId = 3,
                OfferName = "20%",
                OfferDescription = "20% discount on final price"
            };
            //act
            var result = await controller.UpdateOffers(_offer);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        #endregion

        [Fact]
        public async void GetMovieByIdTest()
        {
            //arrange
            var mRepo = OffersMockData.GetOfferByMovieId();
            var controller = new OfferController(mRepo.Object);
            //act
            var result = await controller.GetOfferByMovieId(1);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
