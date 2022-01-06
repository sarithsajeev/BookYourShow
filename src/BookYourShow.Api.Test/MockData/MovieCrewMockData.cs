using BookYourShow.Api.Repository;
using BookYourShow.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using BookYourShow.Models;
using BookYourShow.Api.Controllers;

namespace BookYourShow.Api.Test.MockData
{
    public class MovieCrewMockData
    {
        public async static Task<List<MovieCrewModel>> GetMovieCrews()
        {
            var _members = new List<MovieCrewModel>() {
                new MovieCrewModel()
                {
                    MovieCrewId=1,
                     MemberId=1,
                     MemberName="Lijo Jose Pelliserry",
                     RoleName="Director",
                     MovieId=1,
                     MovieTitle="Churuli"
                },
                new MovieCrewModel()
                {
                    MovieCrewId=2,
                     MemberId=3,
                     MemberName="Stan Lee",
                     RoleName="Script",
                     MovieId=34,
                     MovieTitle="Avengers"
                },
                 new MovieCrewModel()
                {
                    MovieCrewId=3,
                     MemberId=2,
                     MemberName="Jacob",
                     RoleName="Asst.Director",
                     MovieId=1,
                     MovieTitle="Churuli"
                }

            };
            return _members;
        }


        public static Mock<IMovieCrewRepo> AddMovieCrew_Mock()
        {
            var crew = new List<MovieCrew>()
            {
                new MovieCrew()
                {
                    MovieCrewId=1,
                    MemberId=10,
                    RoleName="Director",
                    MovieId=1

                }

            };


            var mockRepo = new Mock<IMovieCrewRepo>();
            mockRepo.Setup(r => r.AddCrewMember(It.IsAny<MovieCrew>())).ReturnsAsync((MovieCrew member) =>
            {
                crew.Add(member);
                return member;
            });


            return mockRepo;
        }


        public static Mock<IMovieCrewRepo> UpdateMovieCrew_Mock()
        {
            var crew = new MovieCrew()
            {
                MovieCrewId = 1,
                MemberId = 10,
                RoleName = "Screenplay",
                MovieId = 1
            };


            var mockRepo = new Mock<IMovieCrewRepo>();
            mockRepo.Setup(r => r.UpdateCrewMember(It.IsAny<MovieCrew>())).ReturnsAsync(crew);
            return mockRepo;
        }

        public static Mock<IMovieCrewRepo> DeleteMovieCrew_Mock()
        {
            var crew = new MovieCrew()
            {
                MovieCrewId = 2,
                MemberId = 11,
                RoleName = "Director",
                MovieId = 2
            };
            var mockRepo = new Mock<IMovieCrewRepo>();
            mockRepo.Setup(r => r.DeleteCrewMember(2)).ReturnsAsync(crew);
            return mockRepo;
        }

        public static Mock<IMovieCrewRepo> GetMovieCrewById_Mock()
        {
            var crew =

                new MovieCrew()
                {
                    MovieCrewId = 1,
                    MemberId = 10,
                    RoleName = "Director",
                    MovieId = 1
                };


            var mockRepo = new Mock<IMovieCrewRepo>();
            mockRepo.Setup(r => r.GetCrewMember(1)).ReturnsAsync(crew);
            return mockRepo;
        }
    }
}
