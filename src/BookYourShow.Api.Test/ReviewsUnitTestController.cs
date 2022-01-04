using BookYourShow.Api.Controllers;
using BookYourShow.Models;
using BookYourShow.Api.Repository;
using BookYourShow.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookYourShow.Api.Test
{
    public class ReviewsUnitTestController
    {
        [Theory]
        [InlineData(1, 100)]

        public void GetReviewsById(int valid, int Invalid)
        {


            List<ReviewModel> emptyReponse = new List<ReviewModel>();

            var _reviews = new List<ReviewModel>()
            {
                new ReviewModel() { MovieTitle = "Spiderman", Comments = "Good"},
                new ReviewModel() { MovieTitle = "Spiderman", Comments = "Amazing" }
            };


            //for ok response
            //arrange
            var mockRepo = new Mock<IReviewsrepo>();


            mockRepo.Setup(n => n.ViewAllReview(valid)).ReturnsAsync(_reviews);
            var controller = new ReviewsController(mockRepo.Object);

            //act
            var result = controller.ViewAllReview(valid);


            //assert
            var viewResult = Assert.IsType<OkObjectResult>(result.Result);
            var viewResultValue = Assert.IsType<List<ReviewModel>>(viewResult.Value);
            Assert.Equal(2, viewResultValue.Count);
            Assert.Equal(_reviews[0].MovieTitle, viewResultValue[0].MovieTitle);


            //for notfound response
            //arrange

            mockRepo.Setup(n => n.ViewAllReview(Invalid)).ReturnsAsync(emptyReponse);
            var controller2 = new ReviewsController(mockRepo.Object);

            //act 
            var notFoundResult = controller2.ViewAllReview(Invalid);

            //assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }


        [Fact]

        public void AddingReviews()
        {
            //ok response
            //arrange
            var reviews = new List<Reviews>();
            var MockRepo = new Mock<IReviewsrepo>();

            MockRepo.Setup(r => r.AddReviews(It.IsAny<Reviews>())).ReturnsAsync(4);


            var controller = new ReviewsController(MockRepo.Object);
            var newValidItem = new Reviews()
            {
                MovieId = 2,
                Comments = "Amazing Movie"
            };

            //act
            var result = controller.AddReviews(newValidItem);

            //assert

            Assert.IsType<OkObjectResult>(result.Result);


            //BadRequest

            //arrange


            var newInValidItem = new Reviews()
            {
                Comments = "Amazing Movie"
            };

            controller.ModelState.AddModelError("MovieId", "MovieId is required");


            //act 
            var badrequestResult = controller.AddReviews(newInValidItem);

            //assert
            Assert.IsType<BadRequestResult>(badrequestResult.Result);

        }

        [Fact]
        public void UpdatingReviews()
        {
            // OK response
            //arrange
            var reviews = new List<Reviews>();
            var MockRepo = new Mock<IReviewsrepo>();

            var expectedResponse = new Reviews()
            {
                ReviewId = 2,
                MovieId = 1,
                Comments = "Good"
            };
            MockRepo.Setup(r => r.UpdateReviews(It.IsAny<Reviews>())).ReturnsAsync(expectedResponse);


            var controller = new ReviewsController(MockRepo.Object);
            var newValidItem = new Reviews()
            {
                ReviewId = 2,
                MovieId = 1,
                Comments = "Good"
            };

            //act
            var result = controller.UpdateReviews(newValidItem);

            //assert

            var actualResponse = Assert.IsType<OkObjectResult>(result.Result);
            var actualResult = Assert.IsType<Reviews>(actualResponse.Value);
            Assert.Equal(expectedResponse.Comments, actualResult.Comments);

            //NotFound

            //arrange
            Reviews notfoundItem = null;

            MockRepo.Setup(r => r.UpdateReviews(It.IsAny<Reviews>())).ReturnsAsync(notfoundItem);

            //act
            var controller1 = new ReviewsController(MockRepo.Object);

            var newValidItem2 = new Reviews()
            {
                ReviewId = 100,
                MovieId = 1,
                Comments = "Good"
            };

            var notFoundResponse = controller1.UpdateReviews(newValidItem2);

            //assert
            Assert.IsType<NotFoundResult>(notFoundResponse.Result);



            //BadRequest

            var newInValidItem = new Reviews()
            {
                Comments = "Amazing Movie"
            };

            controller1.ModelState.AddModelError("MovieId", "MovieId is required");


            //act 
            var badrequestResult = controller1.UpdateReviews(newInValidItem);

            //assert
            Assert.IsType<BadRequestResult>(badrequestResult.Result);
        }


        [Theory]
        [InlineData(2, 100)]

        public void DeletingReviews(int valid, int Invalid)
        {

            var deletingItem = new Reviews()
            {
                ReviewId = 2,
                MovieId = 1,
                Comments = "Good"
            };

            Reviews notfoundItem = null;

            //for ok response
            //arrange
            var mockRepo = new Mock<IReviewsrepo>();


            mockRepo.Setup(n => n.DeleteReview(valid)).ReturnsAsync(deletingItem);
            var controller = new ReviewsController(mockRepo.Object);

            //act
            var result = controller.DeleteReview(valid);


            //assert
            Assert.IsType<OkObjectResult>(result.Result);




            //for notfound response
            //arrange

            mockRepo.Setup(n => n.DeleteReview(Invalid)).ReturnsAsync(notfoundItem);
            var controller2 = new ReviewsController(mockRepo.Object);

            //act 
            var notFoundResult = controller2.DeleteReview(Invalid);

            //assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);



        }
    }
}
