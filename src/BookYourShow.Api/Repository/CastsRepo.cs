using BookYourShow.Models;
using BookYourShow.Api.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public class CastsRepo: ICastsRepo
    {
        BookYourShowContext db;

        public CastsRepo(BookYourShowContext _db)
        {
            db = _db;
        }

        //Get all casts in a movie
        public async Task<List<CastViewModel>> GetCasts(int id)
        {
            if (db != null)
            {
                return await (from cs in db.Casts
                              join a in db.Actors on cs.ActorId equals a.ActorId
                              join m in db.Movies on cs.MovieId equals m.MovieId
                              where m.MovieId == id
                              select new CastViewModel
                              {
                                   CastId=cs.CastId,
                                   ActorId= a.ActorId,
                                   ActorName=a.ActorName,
                                   MovieId= cs.MovieId,
                                   MovieTitle=m.MovieTitle,
                                   RoleName=cs.RoleName,
                                   IsActive=a.IsActive
                              }
                    ).ToListAsync();
            }
            return null;
        }

        //Get cast by id
        public async Task<Casts> GetCast(int id)
        {
            if (db != null)
            {
                return await db.Casts.FirstOrDefaultAsync(em => em.CastId == id);
            }
            return null;
        }

        //Add cast
        public async Task<Casts> AddCast(Casts cast)
        {
            if (db != null)
            {
                await db.Casts.AddAsync(cast);
                await db.SaveChangesAsync();
                return cast;
            }
            return null;
        }

        //Update cast
        public async Task<Casts> UpdateCast(Casts cast)
        {
            if (db != null)
            {
                db.Casts.Update(cast);
                await db.SaveChangesAsync();
                return cast;
            }
            return null;

        }

        //Delete cast
        public async Task<Casts> DeleteCast(int id)
        {
            if (db != null)
            {
                Casts cast = await db.Casts.FirstOrDefaultAsync(em => em.CastId == id);
                db.Remove(cast);
                await db.SaveChangesAsync();
                return cast;
            }
            return null;
        }

        //delete all casts in a movie
        public async Task<List<Casts>> DeleteCasts(int id)
        {
            if (db != null)
            {
                var casts = await (
                        from cs in db.Casts
                        where cs.MovieId == id
                        select new Casts
                        {
                            CastId = cs.CastId,
                            ActorId = cs.ActorId,
                            RoleName = cs.RoleName,
                            MovieId = cs.MovieId
                        }
                    ).ToListAsync();
                db.RemoveRange(casts);
                await db.SaveChangesAsync();
                return casts;
            }
            return null;
        }
    }
    }
