using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public interface ILanguageRepository
    {
        /// <summary>
        /// display languages
        /// </summary>
        /// <returns></returns>
        Task<List<Languages>> GetLanguages();
        /// <summary>
        /// insert language
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        Task<Languages> AddLanguage(Languages language);
        /// <summary>
        /// delete language
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Languages> DeleteLanguage(int id);
    }
}
