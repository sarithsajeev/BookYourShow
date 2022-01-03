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

        #region GenreTest
        public static async Task<List<Genres>> GetGenres()
        {
            var _genre = new List<Genres>()
            {
                new Genres()
                {
                    GenreId =12,
                    Genre = "Sci-Fi"
                }
            };
            return _genre;
        }
        public static Mock<IGenreRepository> AddGenreTest()
        {
            var genres = new List<Genres>()
            {
                new Genres()
                {
                   GenreId = 5,
                    Genre = "Sci-Fi"
                },
                new Genres()
                {
                   GenreId = 6,
                   Genre = "Fantasy"
                }
            };

            var mockRepo = new Mock<IGenreRepository>();
            mockRepo.Setup(r => r.AddGenre(It.IsAny<Genres>())).ReturnsAsync((Genres genre) =>
            {
                genres.Add(genre);
                return genre;
            });
            return mockRepo;
        }
        public static Mock<IGenreRepository> DeleteGenreMock()
        {
            var genres = new Genres()
            {
                GenreId = 5,
                Genre = "Sci-Fi"
            };
            var mockRepo = new Mock<IGenreRepository>();
            mockRepo.Setup(r => r.DeleteGenre(5)).ReturnsAsync(genres);
            return mockRepo;
        }
        #endregion

        #region LanguageTest
        public static async Task<List<Languages>> GetLanguages()
        {
            var _language = new List<Languages>()
            {
                new Languages()
                {
                    LangId =12,
                    Language = "English"
                }
            };
            return _language;
        }
        public static Mock<ILanguageRepository> AddLanguageTest()
        {
            var languages = new List<Languages>()
            {
                new Languages()
                {
                   LangId = 5,
                   Language = "French"
                },
                new Languages()
                {
                   LangId = 6,
                   Language = "Thai"
                }
            };

            var mockRepo = new Mock<ILanguageRepository>();
            mockRepo.Setup(r => r.AddLanguage(It.IsAny<Languages>())).ReturnsAsync((Languages language) =>
            {
                languages.Add(language);
                return language;
            });
            return mockRepo;
        }
        public static Mock<ILanguageRepository> DeleteLanguageMock()
        {
            var languages = new Languages()
            {
                LangId = 6,
                Language = "Thai"
            };
            var mockRepo = new Mock<ILanguageRepository>();
            mockRepo.Setup(r => r.DeleteLanguage(6)).ReturnsAsync(languages);
            return mockRepo;
        }
        #endregion

    }
}
