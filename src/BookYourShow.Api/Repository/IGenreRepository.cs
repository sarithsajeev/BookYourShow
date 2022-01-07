using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public interface IGenreRepository
    {
        /// <summary>
        /// display genres
        /// </summary>
        /// <returns></returns>
        Task<List<Genres>> GetGenres();
        /// <summary>
        /// add genre
        /// </summary>
        /// /// <param name="genre"></param>
        /// <returns></returns>
        Task<Genres> AddGenre(Genres genre);
        /// <summary>
        /// delete genre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Genres> DeleteGenre(int id);
    }
}
