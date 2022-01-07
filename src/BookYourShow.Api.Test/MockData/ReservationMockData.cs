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
    public class ReservationMockData
    {
        public async static Task<List<ReservationModel>> GetAllReservations()
        {
            var _reservations = new List<ReservationModel>()
            {
                new ReservationModel()
                {
                    ReservationId= 1,
                    MovieTitle= "Spiderman",
                    ShowTimeStart= new DateTime(2021,12,17),
                    TheatreName= "Inox",
                    UserName= "Sarith",
                    TicketCount= 3,
                    PaymentInfo= "600 paid"
                },
                new ReservationModel()
                {
                    ReservationId= 1,
                    MovieTitle= "Spiderman",
                    ShowTimeStart= new DateTime(2021,12,17),
                    TheatreName= "Inox",
                    UserName= "Sarith",
                    TicketCount= 3,
                    PaymentInfo= "600 paid"
                }
            };

            return _reservations;
        }

        public static Mock<IReservationRepo> AddReservationRepoMock()
        {
            var reservations = new List<Reservation>()
            {
                new Reservation()
                {
                    ReservationId= 1,
                    ShowTimeId = 2,
                    UserId =2,
                    TicketCount= 3,
                    PaymentInfo= "600 paid"
                },
                new Reservation()
                {
                    ReservationId= 2,
                    ShowTimeId = 1,
                    UserId =1,
                    TicketCount= 3,
                    PaymentInfo= "600 paid"
                }
            };

            var mockRepo = new Mock<IReservationRepo>();
            mockRepo.Setup(r => r.AddReservation(It.IsAny<Reservation>())).ReturnsAsync((Reservation reservation) =>
            {
                reservations.Add(reservation);
                return reservation.ReservationId;
            });

            return mockRepo;
        }


        public static Mock<IReservationRepo> DeleteReservationRepoMock()
        {
            var delReservation = new Reservation()
            {
                ReservationId = 1,
                ShowTimeId = 2,
                UserId = 2,
                TicketCount = 3,
                PaymentInfo = "600 paid"
            };

            var mockRepo = new Mock<IReservationRepo>();
            mockRepo.Setup(r => r.DeleteReservation(delReservation.ReservationId)).ReturnsAsync(true);

            return mockRepo;
        }


        public static Mock<IReservationRepo> UpdateReservationRepoMock()
        {
            var seats = new SeatsView()
            {
                Seats = new int[] {1, 2, 3},
                ReservationId = 1
            };

            var mockRepo = new Mock<IReservationRepo>();
            mockRepo.Setup(r => r.ReserveSeat(It.IsAny<SeatsView>())).ReturnsAsync(true);

            return mockRepo;
        }
    }
}
