using BookYourShow.Models;
using BookYourShow.Api.Repository;
using BookYourShow.Api.Controllers;
using BookYourShow.Api.ViewModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Test.MockData
{
    public class CastsMockData
    {
        public async static Task<List<CastViewModel>> GetCastsByMovieId_Mock()
        {
            var cast = new List<CastViewModel>() {

                new CastViewModel()
                {
                    CastId = 1,
                    ActorId = 10,
                    ActorName="Robert Downey Jr.",
                    MovieId = 1,
                    MovieTitle="Avengers",
                    RoleName = "Tony Stark",
                    IsActive=true

                },
                new CastViewModel()
                {
                    CastId = 2,
                    ActorId = 11,
                    ActorName="Chris Hemsworth",
                    MovieId = 1,
                    MovieTitle="Avengers",
                    RoleName = "Thor Odinson",
                    IsActive=true
                }
                };


            return cast;
        }


        public static Mock<ICastsRepo> AddCast_Mock()
        {
            var casts = new List<Casts>()
            {
                new Casts()
                {
                    CastId=3,
                    ActorId=12,
                    RoleName="Captain America",
                    MovieId=1
                   
                }
               
            };


            var mockRepo = new Mock<ICastsRepo>();
            mockRepo.Setup(r => r.AddCast(It.IsAny<Casts>())).ReturnsAsync((Casts cast) =>
            {
                casts.Add(cast);
                return cast;
            });


            return mockRepo;
        }


        public static Mock<ICastsRepo> UpdateCast_Mock()
        {
            var cast = new Casts()
            {
                CastId = 3,
                ActorId = 12,
                RoleName = "Captain America Jr.",
                MovieId = 1
            };


            var mockRepo = new Mock<ICastsRepo>();
            mockRepo.Setup(r => r.UpdateCast(It.IsAny<Casts>())).ReturnsAsync(cast);
            return mockRepo;
        }

        public static Mock<ICastsRepo> DeleteCast_Mock()
        {
            var cast = new Casts()
            {
                CastId = 3,
                ActorId = 12,
                RoleName = "Captain America Jr.",
                MovieId = 1
            };
            var mockRepo = new Mock<ICastsRepo>();
            mockRepo.Setup(r => r.DeleteCast(3)).ReturnsAsync(cast);
            return mockRepo;
        }

        public static Mock<ICastsRepo> GetCastById_Mock()
        {
            var cast = 

                new Casts()
                {
                    CastId = 3,
                    ActorId = 12,
                    RoleName = "Captain America Jr.",
                    MovieId = 1
                };


            var mockRepo = new Mock<ICastsRepo>();
            mockRepo.Setup(r => r.GetCast(3)).ReturnsAsync(cast);
            return mockRepo;
        }
    }
}
