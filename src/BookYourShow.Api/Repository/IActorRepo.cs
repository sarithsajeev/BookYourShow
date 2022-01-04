using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public interface IActorRepo
    {
        //Get all actors
        Task<List<Actors>> GetActors();

        //Get actor by id
        Task<Actors> GetActor(int id);

        //Add actor
        Task<Actors> AddActor(Actors actor);

        //Delete actor
        Task<Actors> DeleteActor(int id);

        //Update actor
        Task<Actors> UpdateActor(Actors actor);

    }
}
