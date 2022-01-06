using BookYourShow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
    public class SeatRepository:ISeatRepository
    {
        BookYourShowContext db;

        public SeatRepository(BookYourShowContext _db)
        {
            db = _db;
        }
        #region add a seat

        public async Task<int> AddSeat(Seats seat, int tId)
        {
            if (db != null)
            {

                await db.Seats.AddAsync(seat);
                seat.TheatreId = tId;
                await db.SaveChangesAsync(); //commit the transaction
                return seat.SeatId;

            }
            return 0;
        }

        #endregion

        #region get seat by Id

        public async Task<Seats> GetSeatById(int tId, int seatId)
        {
            var s = db.Seats.FirstOrDefault(em => em.SeatId == seatId && em.TheatreId == tId);

            if (s!=null)

                return s;

            return null;
        }

        #endregion

        #region get all seats

        public async Task<List<Seats>> GetSeats(int tId)
        {
            if (db != null )

            {
                return await (from t in db.Theatre
                              from s in db.Seats
                              where tId == t.TheatreId &&
                              t.TheatreId == s.TheatreId &&
                              s.IsActive==true
                              select new Seats
                              {
                                  SeatId = s.SeatId,
                                  Row = s.Row,
                                  Number = s.Number,
                                  Status = s.Status,
                                  ReservationId = s.ReservationId,
                                  TheatreId = tId,
                                  IsActive = s.IsActive

                              }

                ).ToListAsync();

            }
            return null;
        }

        #endregion


        #region update seat details

        public async Task UpdateSeat(Seats seat, int tId)
        {
            if (db != null)
            {
                db.Seats.Update(seat);
                await db.SaveChangesAsync(); //commit the transaction


            }
        }

        #endregion

     

    }
}
