using BookYourShow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShowAPI.Repositories
{
    public class TheatreRepo:ITheatreRepo
    {
        BookYourShowContext db;
        public TheatreRepo(BookYourShowContext _db)
        {
            db = _db;
        }
        #region Add Theatre
        public async Task<int> AddTheatre(Theatre theatre)
        {
            if (db != null)
            {
                await db.Theatre.AddAsync(theatre);
                await db.SaveChangesAsync();
                return theatre.TheatreId;
            }
            return 0;
        }
        #endregion

        #region Get Theatre
        public async Task<List<Theatre>> GetTheatre()
        {
            if (db != null)
            {
                return await db.Theatre.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Get Theatre By ID
        public async Task<Theatre> GetTheatreById(int theatreId)
        {
            if (db != null)
            {
                Theatre result = await db.Theatre.FirstOrDefaultAsync(em => em.TheatreId == theatreId);
                return result;
            }
            return null;
        }
        #endregion

        #region Update Theatre

        public async Task<bool> UpdateTheatre(Theatre theatre)
        {
            if (db != null)
            {
                db.Theatre.Update(theatre);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
    }
}
