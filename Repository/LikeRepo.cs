using BookYourShow.Models;
using BookYourShow.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
    public class LikeRepo : ILikeRepo
    {
        //database/json
        BookYourShowContext db;

        //Constructor dependency injection
        public LikeRepo(BookYourShowContext _db)
        {
            db = _db;
        }
        public async Task<int> AddLike(Likes like)
        {
            if (db != null)
            {
                await db.Likes.AddAsync(like);
                await db.SaveChangesAsync();//commit the transaction
                return like.LikeId;
            }
            return 0;
        }

        public async Task<List<LikeViewModel>> GetLike()
        {
            if (db != null)
            {
                //LINQ
                return await(from l in db.Likes
                             from m in db.Movies
                             from u in db.Users
                             where l.UserId == u.UserId
                             where l.MovieId == m.MovieId
                             select new LikeViewModel
                             {
                                 LikeId = l.LikeId,
                                 UserId = l.UserId,
                                 MovieId = l.MovieId,
                                 UserName = u.UserName,
                                 MovieTitle = m.MovieTitle,
                                 IsActive = l.IsActive

                             }
                             ).ToListAsync();
            }
            return null;
        }

        public async Task<LikeViewModel> GetLikeById(int id)
        {
            if (db != null)
            {
                //LINQ
                //join payment bill and patient
                return await (from l in db.Likes
                              from m in db.Movies
                              from u in db.Users
                              where l.LikeId == id && l.MovieId == m.MovieId
                              where l.LikeId == id && l.UserId == u.UserId
                              select new LikeViewModel
                              {
                                  LikeId = l.LikeId,
                                  MovieId = l.MovieId,
                                  UserId = l.UserId,
                                  MovieTitle = m.MovieTitle,
                                  UserName= u.UserName,
                                  IsActive = l.IsActive
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task UpdateLike(Likes like)
        {
            if (db != null)
            {
                db.Likes.Update(like);
                await db.SaveChangesAsync();//commit the transaction

            }
        }
    }
}
