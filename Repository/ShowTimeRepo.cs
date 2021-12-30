using BookYourShow.Models;
using BookYourShow.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
    public class ShowTimeRepo: IShowTimeRepo
    {
        BookYourShowContext db;

        //constructor dependancy injection
        public ShowTimeRepo(BookYourShowContext _db)
        {
            db = _db;
        }

        public async Task<ShowTime> AddShowTime(ShowTime showTime)
        {
           
            if (db != null)
            {
                await db.ShowTime.AddAsync(showTime);
                await db.SaveChangesAsync();
                return showTime;
            }
            return null;
            

        }

        public async Task<List<ShowTimeView>> GetShowTime()
        {
            if (db != null)
            {
                //LINQ
                return await (from a in db.ShowTime
                              from p in db.Theatre
                              
                              where a.TheatreId == p.TheatreId
                             
                              select new ShowTimeView
                              {
                                  ShowTimeId = a.ShowTimeId,
                                  TheatreId = a.TheatreId,
                                  MovieId = a.MovieId,
                                  ShowTimeStart = a.ShowTimeStart,
                                  TheatreName = p.TheatreName
                              }
                ).ToListAsync();
            }
            return null;
        }


        public async Task<ShowTimeView> GetShowTimeById(int id)
        {
            if (db != null)
            {
                //LINQ
                //join payment bill and patient

                return await (from a in db.ShowTime
                              from p in db.Theatre

                              where a.TheatreId == p.TheatreId && p.TheatreId==id

                              select new ShowTimeView
                              {
                                  ShowTimeId = a.ShowTimeId,
                                  TheatreId = a.TheatreId,
                                  MovieId = a.MovieId,
                                  ShowTimeStart = a.ShowTimeStart,
                                  TheatreName = p.TheatreName,
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task UpdateShowTime(ShowTime showtime)
        {
            if (db != null)
            {
                db.ShowTime.Update(showtime);
                await db.SaveChangesAsync(); //commit the transaction

            }
        }
    }
}
