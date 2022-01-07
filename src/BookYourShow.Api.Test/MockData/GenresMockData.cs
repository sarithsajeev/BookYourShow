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
    public class GenresMockData
    {
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

    }
}
