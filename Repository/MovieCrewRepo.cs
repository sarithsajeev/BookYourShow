using BookYourShow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
    public class MovieCrewRepo: IMovieCrewRepo
    {
        BookYourShowContext db;

        public MovieCrewRepo(BookYourShowContext _db)
        {
            db = _db;
        }

        //Get all crew members in a movie
        public async Task<List<MovieCrew>> GetCrewMembers(int id)
        {
            if (db != null)
            {
                return await (from mc in db.MovieCrew
                              where mc.MovieId == id
                              select new MovieCrew
                              {
                                  MovieCrewId = mc.MovieCrewId,
                                  MemberId = mc.MemberId,
                                  RoleName = mc.RoleName,
                                  MovieId = mc.MovieId
                              }
                    ).ToListAsync();
            }
            return null;
        }

        //Get crew member by id
        public async Task<MovieCrew> GetCrewMember(int id)
        {
            if (db != null)
            {
                return await db.MovieCrew.FirstOrDefaultAsync(em => em.MovieCrewId == id);
            }
            return null;
        }

        //Add crew member of a movie
        public async Task<MovieCrew> AddCrewMember(MovieCrew member)
        {
            if (db != null)
            {
                await db.MovieCrew.AddAsync(member);
                await db.SaveChangesAsync();
                return member;
            }
            return null;
        }

        //Update crew member of a movie
        public async Task<MovieCrew> UpdateCrewMember(MovieCrew member)
        {
            if (db != null)
            {
                db.MovieCrew.Update(member);
                await db.SaveChangesAsync();
                return member;
            }
            return null;

        }

        //Delete crew member
        public async Task<MovieCrew> DeleteCrewMember(int id)
        {
            if (db != null)
            {
                MovieCrew member = await db.MovieCrew.FirstOrDefaultAsync(em => em.MovieCrewId == id);
                db.Remove(member);
                await db.SaveChangesAsync();
                return member;
            }
            return null;
        }

        //delete all crew members in a movie
        public async Task<List<MovieCrew>> DeleteCrewMembers(int id)
        {
            if (db != null)
            {
                var crew = await (
                        from mc in db.MovieCrew
                        where mc.MovieId == id
                        select new MovieCrew
                        {
                            MovieCrewId=mc.MovieCrewId,
                            MemberId=mc.MemberId,
                            RoleName = mc.RoleName,
                            MovieId = mc.MovieId
                        }
                    ).ToListAsync();
                db.RemoveRange(crew);
                await db.SaveChangesAsync();
                return crew;
            }
            return null;
        }
    }
}
