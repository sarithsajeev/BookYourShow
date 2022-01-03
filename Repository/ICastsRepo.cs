using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookYourShow.V

namespace BookYourShow.Repository
{
    public  interface ICastsRepo
    {
        //Get all casts in a movie
        Task<List<CastViewModel>> GetCasts(int id);

        //Get cast by id
        Task<Casts> GetCast(int id);

        //Add cast
        Task<Casts> AddCast(Casts cast);

        //Delete cast by id
        Task<Casts> DeleteCast(int id);

        //Update cast
        Task<Casts> UpdateCast(Casts cast);

        //delete all casts in a movie
        Task<List<Casts>> DeleteCasts(int id);
    }
}
