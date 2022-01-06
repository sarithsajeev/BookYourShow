using BookYourShow.Models;
using BookYourShow.Api.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookYourShow.Api.Test.MockData
{
    public class CityMockData
    {
        public static async Task<List<City>> GetAllCities()
        {
            var _cities = new List<City>()
            {
                new City()
                {
                    CityId =12,
                    CityName = "Aluva",
                    Zipcode = "683561",
                    State ="Kerala",
                    IsActive = true
                }
            };
            return _cities;
        }

        public static Mock<ICityRepo> GetCityByIdTest()
        {
            var cities = new City()
            {
                    CityId =12,
                    CityName = "Aluva",
                    Zipcode = "683561",
                    State ="Kerala",
                    IsActive = true
               
            };

         
            var mockRepo = new Mock<ICityRepo>();
            mockRepo.Setup(r => r.GetCity(12)).ReturnsAsync(cities);
            return mockRepo;
        }

        public static Mock<ICityRepo> AddCityTest()
        {
            var cities = new List<City>()
            {
                new City()
                {
                    CityId =12,
                    CityName = "Aluva",
                    Zipcode = "683561",
                    State ="Kerala",
                    IsActive = true

            },
                new City()
                {
                    CityId =15,
                    CityName = "Vazhakala",
                    Zipcode = "683451",
                    State ="Kerala",
                    IsActive = true

            }
            };

            var mockRepo = new Mock<ICityRepo>();
            mockRepo.Setup(r => r.AddCity(It.IsAny<City>())).ReturnsAsync((City city) =>
            {
                cities.Add(city);
                return city.CityId;
            });
            return mockRepo;
        }



        public static Mock<ICityRepo> UpdateCityMock()
        {
            var cities = new City()
            {
                CityId = 12,
                CityName = "Aluva",
                Zipcode = "683561",
                State = "Kerala",
                IsActive = true
            };
            var mockRepo = new Mock<ICityRepo>();
            mockRepo.Setup(r => r.UpdateCity(It.IsAny<City>())).ReturnsAsync(cities);
            return mockRepo;
        }

        public static Mock<ICityRepo> UpdateCityStatusMock()
        {
            var cities = new City()
            {
                CityId = 12,
                CityName = "Aluva",
                Zipcode = "683561",
                State = "Kerala",
                IsActive = true
            };
            var mockRepo = new Mock<ICityRepo>();
            mockRepo.Setup(r => r.UpdateCityActiveStatus(12)).ReturnsAsync(cities);
            return mockRepo;
        }


    }
}
