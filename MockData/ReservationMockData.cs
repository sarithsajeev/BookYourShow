using BookYourShow.Models;
using BookYourShow.ViewModel;
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
    }
}
