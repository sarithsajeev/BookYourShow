using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
    public class ReservationRepo : IReservationRepo
    {
        BookYourShowContext db;
        public ReservationRepo(BookYourShowContext _db)
        {
            db = _db;
        }

        public async Task<int> AddReservation(Reservation reserve)
        {
            if (db != null)
            {
                await db.Reservation.AddAsync(reserve);
                await db.SaveChangesAsync();
                return reserve.ReservationId;
            }
            return 0;
        }
    }
}
