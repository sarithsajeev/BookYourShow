using BookYourShow.Models;
using BookYourShowAPI.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookYourShow.Api.Test.MockData
{
    public class MockData
    {
        public static async Task<List<Theatre>> GetTheatre()
        {
            var _theatres = new List<Theatre>()
                {
                new Theatre()
                    {
                        TheatreId =10,
                        TheatreName = "Pluto Ciniplex",
                        Location="Gayatripuram",
                        CityId=1,
                        IsActive=true
                    }
                };
            return _theatres;
        }



        public static Mock<ITheatreRepo> GetTheatreByIdMock()
        {
            var _theatre = new Theatre()
            {
                TheatreId = 1,
                TheatreName = "Pluto Ciniplex",
                Location = "Gayatripuram",
                CityId = 1,
                IsActive = true
            };



            var mockRepo = new Mock<ITheatreRepo>();
            mockRepo.Setup(r => r.GetTheatreById(1)).ReturnsAsync(_theatre);
            return mockRepo;
        }



        public static Mock<ITheatreRepo> AddTheatreRepoMock()
        {
            var _theatres = new List<Theatre>()
            {
            new Theatre()
            {
            TheatreId =11,
            TheatreName = "PLR Ciniplex",
            Location="lakshmipuram",
            CityId=1,
            IsActive=true
            },
            new Theatre()
            {
            TheatreId =12,
            TheatreName = "BMT Ciniplex",
            Location="Vijayanagar",
            CityId=2,
            IsActive=true
            },
            };
            var mockRepo = new Mock<ITheatreRepo>();
            mockRepo.Setup(r => r.AddTheatre(It.IsAny<Theatre>())).ReturnsAsync((Theatre theatre) =>
            {
                _theatres.Add(theatre);
                return theatre.TheatreId;
            });
            return mockRepo;
        }



        public static Mock<ITheatreRepo> UpdateTheatreMock()
        {
            var _theatre = new Theatre()
            {
                TheatreId = 12,
                TheatreName = "BMT Ciniplex",
                Location = "Vijayanagar",
                CityId = 2,
                IsActive = true
            };



            var mockRepo = new Mock<ITheatreRepo>();
            mockRepo.Setup(r => r.UpdateTheatre(It.IsAny<Theatre>())).ReturnsAsync(true);
            return mockRepo;
        }
    }
}

