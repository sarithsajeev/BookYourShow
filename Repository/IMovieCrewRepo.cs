using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
     public interface IMovieCrewRepo
    {
        //Get all crew member in a movie
        Task<List<MovieCrew>> GetCrewMembers(int id);

        //Get crew member by movie crew id
        Task<MovieCrew> GetCrewMember(int id);

        //Add crew member
        Task<MovieCrew> AddCrewMember(MovieCrew member);

        //Delete crew member by movie crew id
        Task<MovieCrew> DeleteCrewMember(int id);

        //Update crew member in a movie
        Task<MovieCrew> UpdateCrewMember(MovieCrew member);

        //delete all crew members in a movie
        Task<List<MovieCrew>> DeleteCrewMembers(int id);
    }
}
