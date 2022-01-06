using BookYourShow.Models;
using BookYourShow.Api.Repository;
using BookYourShow.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;

namespace BookYourShow.Api.Test.MockData
{
    public class ActorsMockData
    {
        public async static Task<List<Actors>> GetActors_Mock()
        {
            var _actor = new List<Actors>()
            {
                new Actors()
                {
                    ActorId=10,
                    ActorName="Robert Downey Jr."
                },
                new Actors()
                {
                    ActorId=11,
                    ActorName="Robert Pattinson"
                }
            };
            return _actor;
        }

        public static Mock<IActorRepo> AddActor_Mock()
        {
            var actors = new List<Actors>()
            {
                new Actors()
                {
                    ActorId=12,
                    ActorName="Christian Bale",
                    IsActive = true
                },
                new Actors()
                {
                    ActorId=13,
                    ActorName="Gal Gadot",
                    IsActive = true
                }
            };


            var mockRepo = new Mock<IActorRepo>();
            mockRepo.Setup(r => r.AddActor(It.IsAny<Actors>())).ReturnsAsync((Actors actor) =>
            {
                actors.Add(actor);
                return actor;
            });


            return mockRepo;
        }


        public static Mock<IActorRepo> UpdateActor_Mock()
        {
            var actor = new Actors()
            {
                ActorId = 12,
                ActorName = "Dwayne Johnson",
                IsActive = true
            };


            var mockRepo = new Mock<IActorRepo>();
            mockRepo.Setup(r => r.UpdateActor(It.IsAny<Actors>())).ReturnsAsync(actor);
            return mockRepo;
        }

        public static Mock<IActorRepo> DeleteActor_Mock()
        {
            var actor = new Actors()
            {
                ActorId=13,
                ActorName="Jackie Chan",
                IsActive = true
            };
            var mockRepo = new Mock<IActorRepo>();
            mockRepo.Setup(r => r.DeleteActor(13)).ReturnsAsync(actor);
            return mockRepo;
        }

        public static Mock<IActorRepo> GetActorById_Mock()
        {
            var actor =

                new Actors()
                {
                    ActorId = 12,
                    ActorName = "Dwayne Johnson",
                    IsActive = true
                };


            var mockRepo = new Mock<IActorRepo>();
            mockRepo.Setup(r => r.GetActor(12)).ReturnsAsync(actor);
            return mockRepo;
        }
    }
}
