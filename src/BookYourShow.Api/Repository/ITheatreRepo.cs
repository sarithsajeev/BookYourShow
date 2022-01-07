using BookYourShow.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShowAPI.Repositories
{
   public interface ITheatreRepo
   {
        Task<int> AddTheatre(Theatre theatre);
        Task<List<Theatre>> GetTheatre();
        Task<Theatre> GetTheatreById(int theatreId);
        Task<bool> UpdateTheatre(Theatre theatre);
   }
}
