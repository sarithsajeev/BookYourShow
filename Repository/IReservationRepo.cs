using BookYourShow.Models;
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
    }
}
