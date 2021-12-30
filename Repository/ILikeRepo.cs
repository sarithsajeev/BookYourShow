using BookYourShow.Models;
using BookYourShow.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
    public interface ILikeRepo
    {
        /// <summary>
        /// add like
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        Task<int> AddLike(Likes like);

        /// <summary>
        /// get like
        /// </summary>
        /// <returns></returns>
        Task<List<LikeViewModel>> GetLike();

        /// <summary>
        /// get like by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<LikeViewModel> GetLikeById(int id);

        /// <summary>
        /// update like
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        Task UpdateLike(Likes like);




    }
}
