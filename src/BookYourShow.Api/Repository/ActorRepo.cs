using BookYourShow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
    public class ActorRepo: IActorRepo
    {
        BookYourShowContext db;
        public ActorRepo(BookYourShowContext _db)
        {
            db = _db;
        }


        //Get all actors
        public async Task<List<Actors>> GetActors()
        {
            if (db != null)
            {
                return await db.Actors.ToListAsync();
            }
            return null;
        }

        //Get actor by id
        public async Task<Actors> GetActor(int id)
        {
            if (db != null)
            {
                return await db.Actors.FirstOrDefaultAsync(em => em.ActorId == id);
            }
            return null;
        }

        //Add actors
        public async Task<Actors> AddActor(Actors actor)
        {
            if (db != null)
            {
                await db.Actors.AddAsync(actor);
                await db.SaveChangesAsync();
                return actor;
            }
            return null;
        }

        //Update actor
        public async Task<Actors> UpdateActor(Actors actor)
        {
            if (db != null)
            {
                db.Actors.Update(actor);
                await db.SaveChangesAsync();
                return actor;
            }
            return null;

        }

        //Delete actor
        public async Task<Actors> DeleteActor(int id)
        {
            if (db != null)
            {
                Actors actor = await db.Actors.FirstOrDefaultAsync(em => em.ActorId == id);
                actor.IsActive = false;
                db.Actors.Update(actor);
                await db.SaveChangesAsync();
                return actor;
            }
            return null;
        }
    }
}
