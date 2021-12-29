using BookYourShow.Models;
using BookYourShow.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
    public interface IReservationRepo
    {
        /// <summary>
        /// add reservation
        /// </summary>
        /// <param name="reserve"></param>
        /// <returns> reservation id </returns>
        Task<int> AddReservation(Reservation reserve);
        
        /// <summary>
        /// Update reservation id in seats
        /// </summary>
        /// <param name="seats"></param>
        /// <returns> true if updated </returns>
        Task<bool> ReserveSeat(SeatsView seats);
    }
}
