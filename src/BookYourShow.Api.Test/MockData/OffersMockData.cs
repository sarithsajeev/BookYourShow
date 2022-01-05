using BookYourShow.Api.Repository;
using BookYourShow.Api.ViewModel;
using BookYourShow.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookYourShow.Api.Test.MockData
{
    public class OffersMockData
    {
        public static async Task<List<OfferViewModel>> OfferByMovie()
        {
            var offers = new List<OfferViewModel>()
            {
                new OfferViewModel()
                {
                     OfferId =1,
                     OfferName =" ten percent",
                     OfferDescription ="ten percent off on price",
                     MovieId =1,
                     MovieTitle ="Spiderman",
                     MovieDesc = "Spiderman",
                     MovieRelease = DateTime.Parse("11-12-2017"),
                     LangId =1,
                     GenreId =1
                }
            };
            return offers;
        }
        public static Mock<IOfferRepository> AddOffersTest()
        {
            var offers = new List<Offers>()
        {
        new Offers()
        {
            OfferId = 2,
            OfferName = "10%",
            OfferDescription = "10% discount on final price"

        },
        new Offers()
        {
            OfferId = 3,
            OfferName = "20%",
            OfferDescription = "20% discount on final price"
        }
        };

            var mockRepo = new Mock<IOfferRepository>();
            mockRepo.Setup(r => r.AddOffers(It.IsAny<Offers>())).ReturnsAsync((Offers offer) =>
            {
                offers.Add(offer);
                return offer;
            });
            return mockRepo;
        }
        public static Mock<IOfferRepository> UpdateOfferTest()
        {
            var offers = new Offers()
            {
                OfferId = 3,
                OfferName = "20%",
                OfferDescription = "20% discount on final price"
            };
            var mockRepo = new Mock<IOfferRepository>();
            mockRepo.Setup(r => r.UpdateOffers(It.IsAny<Offers>())).ReturnsAsync(offers);
            return mockRepo;
        }
        public static Mock<IOfferRepository> GetOfferByMovieId()
        {
            var offer = new List<OfferViewModel>()
            {
                new OfferViewModel()
                {
                     OfferId =1,
                     OfferName =" ten percent",
                     OfferDescription ="ten percent off on price",
                     MovieId =1,
                     MovieTitle ="Spiderman",
                     MovieDesc = "Spiderman",
                     MovieRelease = DateTime.Parse("11-12-2017"),
                     LangId =1,
                     GenreId =1
                }
            };
            var mockRepo = new Mock<IOfferRepository>();
            mockRepo.Setup(r => r.GetOfferByMovieId(1)).ReturnsAsync(offer);
            return mockRepo;
        }
    }
}
