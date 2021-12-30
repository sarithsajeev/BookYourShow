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

        public async Task<List<ReservationModel>> AllReservations()
        {
            return await(from r in db.Reservation
                         join s in db.ShowTime on r.ShowTimeId equals s.ShowTimeId
                         join m in db.Movies on s.MovieId equals m.MovieId
                         join t in db.Theatre on s.TheatreId equals t.TheatreId
                         join u in db.Users on r.UserId equals u.UserId
                         select new ReservationModel
                         {
                             ReservationId = r.ReservationId,
                             MovieTitle = m.MovieTitle,
                             ShowTimeStart = s.ShowTimeStart,
                             TheatreName = t.TheatreName,
                             UserName = u.UserName,
                             TicketCount = r.TicketCount,
                             PaymentInfo = r.PaymentInfo
                         }
                          ).ToListAsync();
        }

        public async Task<bool> DeleteReservation(int id)
        {
            var reservation = await db.Reservation.FirstOrDefaultAsync(x => x.ReservationId == id);
            if (reservation != null)
            {
                db.Remove(reservation);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
