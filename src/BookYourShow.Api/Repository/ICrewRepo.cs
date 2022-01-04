using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public interface ICrewRepo
    {
        //Get all crew members
        Task<List<Crew>> GetCrewMembers();

        //Get crew member by id
        Task<Crew> GetCrewMember(int id);

        //Add member
        Task<Crew> AddCrewMember(Crew crewMember);

        //Delete member
        Task<Crew> DeleteCrewMember(int id);

        //Update member
        Task<Crew> UpdateCrewMember(Crew crewMember);
    }
}