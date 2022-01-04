using BookYourShow.Models;
using BookYourShow.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
     public interface IShowTimeRepo
    {
        /// <summary>
        /// insert showtime
        /// </summary>
        /// <param name="showTime"></param>
        /// <returns></returns>
        Task<ShowTime> AddShowTime(ShowTime showTime);


        /// <summary>
        /// display showtime 
        /// </summary>
        /// <returns></returns>
        Task<List<ShowTimeView>> GetShowTime();

        Task<ShowTimeView> GetShowTimeById(int id);

        Task<bool> UpdateShowTime(ShowTime showtime);
    }
}
