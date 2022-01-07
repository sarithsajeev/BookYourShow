using BookYourShow.Models;
using BookYourShow.Repository;
using BookYourShow.ViewModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.MockData
{
    public class LikeMockData
    {
        public static async Task<List<LikeViewModel>> GetLike()
        {
            var _patients = new List<LikeViewModel>()
           {
              new LikeViewModel()
              {
                   LikeId = 5,
                   MovieId =7,
                   UserId = 1,
                   IsActive = true
              }
           };
            return _patients;
        }

        public static Mock<ILikeRepo> AddLikeMock()
        {
            var likes = new List<Likes>()
            {
                new Likes()
                {
                   LikeId = 5,
                   MovieId =7,
                   UserId = 1,
                   IsActive = true
                },
                new Likes()
                {
                   LikeId = 6,
                   MovieId =7,
                   UserId = 1,
                   IsActive = true
                }
            };

            var mockRepo = new Mock<ILikeRepo>();
            mockRepo.Setup(r => r.AddLike(It.IsAny<Likes>())).ReturnsAsync((Likes like) =>
            {
                likes.Add(like);
                return like.LikeId;
            });

            return mockRepo;
        }
        public static Mock<ILikeRepo> GetLikeByIdMock()
        {
            var like = new LikeViewModel()
            { 
                   LikeId = 5,
                   MovieId =7,
                   UserId = 1,
                   IsActive = true
                              
            };

            var mockRepo = new Mock<ILikeRepo>();
            mockRepo.Setup(r => r.GetLikeById(5)).ReturnsAsync(like);
            return mockRepo;

        }
        public  static Mock<ILikeRepo> UpdateLikeMock()
        {
            var like = new Likes()
            {
                LikeId = 5,
                MovieId = 7,
                UserId = 1,
                IsActive = true

            };


            var mockRepo = new Mock<ILikeRepo>();
            mockRepo.Setup(r => r.UpdateLike(It.IsAny<Likes>())).ReturnsAsync(true);
            return mockRepo;
        }

    }
}
