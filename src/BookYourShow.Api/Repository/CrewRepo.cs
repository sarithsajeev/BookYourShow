using BookYourShow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
    public class CrewRepo : ICrewRepo
    {
        BookYourShowContext db;

        public CrewRepo(BookYourShowContext _db)
        {
            db = _db;
        }

        //Get all crew members
        public async Task<List<Crew>> GetCrewMembers()
        {
            if (db != null)
            {
                return await db.Crew.ToListAsync();
            }
            return null;
        }

        //Get crew member by id
        public async Task<Crew> GetCrewMember(int id)
        {
            if (db != null)
            {
                return await db.Crew.FirstOrDefaultAsync(em => em.MemberId == id);
            }
            return null;
        }

        //Add members
        public async Task<Crew> AddCrewMember(Crew crewMember)
        {
            if (db != null)
            {
                await db.Crew.AddAsync(crewMember);
                await db.SaveChangesAsync();
                return crewMember;
            }
            return null;
        }

        //Update crew member
        public async Task<Crew> UpdateCrewMember(Crew crewMember)
        {
            if (db != null)
            {
                db.Crew.Update(crewMember);
                await db.SaveChangesAsync();
                return crewMember;
            }
            return null;

        }

        //Delete crew member
        public async Task<Crew> DeleteCrewMember(int id)
        {
            if (db != null)
            {
                Crew crewMember = await db.Crew.FirstOrDefaultAsync(em => em.MemberId == id);
                crewMember.IsActive = false;
                db.Crew.Update(crewMember);
                await db.SaveChangesAsync();
                return crewMember;
            }
            return null;
        }
    }
}