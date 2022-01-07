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
    public class MockData
    {
        public static async Task<List<ShowTimeView>> GetAllShowtime()
        {
            var _showtime = new List<ShowTimeView>()
            {
                new ShowTimeView()
                {
                    ShowTimeId = 1,
                    MovieId = 1,
                    TheatreId=1,
                    ShowTimeStart=new DateTime(2021,01,01),
                    TheatreName="Plaza"

                }
            };
            return _showtime;
        }

        public static Mock<IShowTimeRepo> GetShowTimeByIdMock()
        {
            var show = new ShowTimeView()
            {
                ShowTimeId = 1,
                MovieId = 1,
                TheatreId = 1,
                ShowTimeStart = new DateTime(2021, 01, 01),
                TheatreName = "Plaza"

            };



            var mockRepo = new Mock<IShowTimeRepo>();
            mockRepo.Setup(r => r.GetShowTimeById(1)).ReturnsAsync(show);
            return mockRepo;



        }

       
        public static Mock<IShowTimeRepo> AddShowTimeMock()
        {
            var shows = new List<ShowTime>()
            {
                new ShowTime()
            {
                ShowTimeId = 1,
                MovieId = 1,
                TheatreId = 1,
                ShowTimeStart = new DateTime(2021, 01, 01),
               
            },
            new ShowTime()
            {
                ShowTimeId = 2,
                MovieId = 1,
                TheatreId = 1,
                ShowTimeStart = new DateTime(2021, 01, 01),
                
            }
}; var mockRepo = new Mock<IShowTimeRepo>();
            mockRepo.Setup(r => r.AddShowTime(It.IsAny<ShowTime>())).ReturnsAsync((ShowTime show) =>
            {
                shows.Add(show);
                return show;
            }); 
            return mockRepo;
        }


        public static Mock<IShowTimeRepo> UpdateShowTimeMock()
        {
            var show = new ShowTime()
            {
                ShowTimeId = 1,
                MovieId = 1,
                TheatreId = 1,
                ShowTimeStart = new DateTime(2021, 01, 01),
                

            };



            var mockRepo = new Mock<IShowTimeRepo>();
            mockRepo.Setup(r => r.UpdateShowTime(It.IsAny<ShowTime>())).ReturnsAsync(true);
            return mockRepo;



        }

    }
}
