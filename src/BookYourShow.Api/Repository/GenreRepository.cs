using BookYourShow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public class GenreRepository : IGenreRepository
    {
        BookYourShowContext _db;

        public GenreRepository(BookYourShowContext db)
        {
            _db = db;
        }
        //get genres
        public async Task<List<Genres>> GetGenres()
        {
            if (_db != null)
            {
                return await _db.Genres.ToListAsync();
            }
            return null;
        }
        //Add genre
        public async Task<Genres> AddGenre(Genres genre)
        {
            if (_db != null)
            {
                await _db.Genres.AddAsync(genre);
                await _db.SaveChangesAsync();
                return genre;
            }
            return null;

        }
        //delete genre
        public async Task<Genres> DeleteGenre(int id)
        {
            if (_db != null)
            {
                Genres dbgen = _db.Genres.Find(id);
                _db.Genres.Remove(dbgen);
                _db.SaveChanges();

                return (dbgen);
            }
            return null;
        }

    }
}
