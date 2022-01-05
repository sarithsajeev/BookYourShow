using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
    public interface ICityRepo
    {
        /// <summary>
        /// method to add a city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        Task<int> AddCity(City city);

        /// <summary>
        /// Method to get all cities
        /// </summary>
        /// <returns></returns>
        Task<List<City>> GetCities();

        /// <summary>
        /// method to get a city by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<City> GetCity(int id);

        /// <summary>
        /// method to update a city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        Task<City> UpdateCity(City city);

        /// <summary>
        /// method to update active status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<City> UpdateCityActiveStatus(int id);

    }
}
