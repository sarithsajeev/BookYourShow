using BookYourShow.Models;
using BookYourShow.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
    public class TicketsRepo : ITicketsRepo
    {
        private BookYourShowContext contextDB;

        //-- Parameterized constructor  --//
        public TicketsRepo(BookYourShowContext _contextDB)
        {
            contextDB = _contextDB;
        }
        public async Task<List<TicketViewModel>> ViewTickets(int id)
        {
             //-- Creating the db context --//
            if (contextDB != null)
            {
                //LINQ
                return await (from u in contextDB.Users
                              from s in contextDB.Seats
                              from r in contextDB.Reservation
                              from m in contextDB.Movies
                              from sh in contextDB.ShowTime
                              from t in contextDB.Theatre
                              where u.UserId == r.UserId &&
                              r.ReservationId == s.ReservationId && r.ShowTimeId == sh.ShowTimeId && sh.MovieId == m.MovieId && t.TheatreId==s.TheatreId && r.UserId == id
                              select new TicketViewModel
                              {
                                  UserName = u.UserName,
                                  ContactNumber = u.ContactNumber,
                                  Movie = m.MovieTitle,
                                  TheatreName=t.TheatreName,
                                 SeatNumber = s.Number,
                                  TicketCount = r.TicketCount
                              }).ToListAsync();
            }
            return null;
        }
    }
}
