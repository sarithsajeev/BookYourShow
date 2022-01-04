using BookYourShow.Api.Controllers;
using BookYourShow.Models;
using BookYourShow.Api.Repository;
using BookYourShow.Api.ViewModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookYourShow.Api.Test.MockData
{
    public class MoviesMockData
    {
        #region MovieTest
        public static async Task<List<MovieViewModel>> GetAllMovies()
        {
            var _movies = new List<MovieViewModel>()
            {
                new MovieViewModel()
                {
                    MovieId =12,
                    MovieTitle = "The Arrival",
                    MovieDesc = "The Arrival Movie",
                    MovieRelease = DateTime.Parse("11-12-2013"),
                    Language ="English",
                    Genre ="Sci-Fi",
                    OfferName ="Cashback",
                    OfferDescription="10% cashback",
                    IsActive = true
                }
            };
            return _movies;
        }
        public static Mock<IMovieRepository> GetMovieByIdTest()
        {
            var movie = new List<MovieViewModel>()
            {
                new MovieViewModel()
                {
                    MovieId = 12,
                    MovieTitle = "The Arrival",
                    MovieDesc = "The Arrival Movie",
                    MovieRelease = DateTime.Parse("11-12-2013"),
                    Language = "English",
                    Genre = "Sci-Fi",
                    OfferName = "Cashback",
                    OfferDescription = "10% cashback",
                    IsActive = true
                }

            };
            var mockRepo = new Mock<IMovieRepository>();
            mockRepo.Setup(r => r.GetMovieById(12)).ReturnsAsync(movie);
            return mockRepo;
        }

        public static Mock<IMovieRepository> AddMovieTest()
        {
            var movies = new List<Movies>()
            {
                new Movies()
                {
                    MovieId= 13,
                    MovieTitle = "The Martian II",
                    MovieDesc = "The Martian II Movie",
                    MovieRelease = DateTime.Parse("11-12-2017"),
                    LangId = 1,
                    GenreId = 2,
                    OfferId = 1,
                    IsActive = true
                },
                new Movies()
                {
                    MovieId = 14,
                    MovieTitle = "The Martian II",
                    MovieDesc = "The Martian II Movie",
                    MovieRelease = DateTime.Parse("11-12-2017"),
                    LangId = 1,
                    GenreId = 2,
                    OfferId = 1,
                    IsActive = true
                }
            };

            var mockRepo = new Mock<IMovieRepository>();
            mockRepo.Setup(r => r.AddMovie(It.IsAny<Movies>())).ReturnsAsync((Movies movie) =>
            {
                movies.Add(movie);
                return movie;
            });
            return mockRepo;
        }



        public static Mock<IMovieRepository> UpdateMovieMock()
        {
            var movies = new Movies()
            {
                MovieId = 14,
                MovieTitle = "The Martian II",
                MovieDesc = "The Martian II Movie",
                MovieRelease = DateTime.Parse("11-12-2017"),
                LangId = 1,
                GenreId = 2,
                OfferId = 1,
                IsActive = true
            };
            var mockRepo = new Mock<IMovieRepository>();
            mockRepo.Setup(r => r.UpdateMovie(It.IsAny<Movies>())).ReturnsAsync(movies);
            return mockRepo;
        }

        public static Mock<IMovieRepository> DeleteMovieMock()
        {
            var movies = new Movies()
            {
                MovieId = 14,
                MovieTitle = "The Martian II",
                MovieDesc = "The Martian II Movie",
                MovieRelease = DateTime.Parse("11-12-2017"),
                LangId = 1,
                GenreId = 2,
                OfferId = 1,
                IsActive = true
            };
            var mockRepo = new Mock<IMovieRepository>();
            mockRepo.Setup(r => r.DeleteMovie(14)).ReturnsAsync(movies);
            return mockRepo;
        }

        #endregion
    }
}
