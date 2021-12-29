using BookYourShow.Models;
using BookYourShow.ViewModel;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> ReserveSeat(SeatsView seat)
        {
            if(db != null)
            {
                foreach (int seatId in seat.Seats)
                {
                    Seats _seat = await db.Seats.FirstOrDefaultAsync(em => em.SeatId == seatId);
                    _seat.ReservationId = seat.ReservationId;
                    db.Seats.Update(_seat);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            return false;
        }
    }
}
