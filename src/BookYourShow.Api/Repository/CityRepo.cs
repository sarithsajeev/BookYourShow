using BookYourShow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public class CityRepo : ICityRepo
    {
        private BookYourShowContext contextDB;

        public CityRepo(BookYourShowContext _contextDB)
        {
            this.contextDB = _contextDB;
        }



        public async Task<List<City>> GetCities()
        {
            if (contextDB != null)
            {
                return await contextDB.City.ToListAsync();
            }
            return null;
        }

        public async Task<City> GetCity(int id)
        {
            if(contextDB != null)
            {
                return await contextDB.City.FirstOrDefaultAsync(t => t.CityId == id);
            }
            return null;
        }

        public async Task<City> UpdateCity(City city)
        {
            if (contextDB != null)
            {
                contextDB.City.Update(city);
                await contextDB.SaveChangesAsync();
                return city;
            }
            return null;
        }

        public async Task<int> AddCity(City city)
        {
            if (contextDB != null)
            {
                await contextDB.AddAsync(city);
                await contextDB.SaveChangesAsync();
                return city.CityId;
            }
            return 0;
        }

        public async Task<City> UpdateCityActiveStatus(int id)
        {
            City city = contextDB.City.FirstOrDefault(cId => cId.CityId == id);
            if (city != null)
            {
                city.IsActive = false;
                await contextDB.SaveChangesAsync();
                return city;
            }
            return null;
        }
    }
}
