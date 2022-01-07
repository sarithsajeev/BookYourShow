using BookYourShow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        BookYourShowContext _db;

        public LanguageRepository(BookYourShowContext db)
        {
            _db = db;
        }
        //get languages
        public async Task<List<Languages>> GetLanguages()
        {
            if (_db != null)
            {
                return await _db.Languages.ToListAsync();
            }
            return null;
        }
        //Add language
        public async Task<Languages> AddLanguage(Languages language)
        {
            //--- member function to add language ---//
            if (_db != null)
            {
                await _db.Languages.AddAsync(language);
                await _db.SaveChangesAsync();
                return language;
            }
            return null;

        }
        //Delete language
        public async Task<Languages> DeleteLanguage(int id)
        {
            if (_db != null)
            {
                Languages dblang = _db.Languages.Find(id);
                _db.Languages.Remove(dblang);
                _db.SaveChanges();

                return (dblang);
            }
            return null;
        }

    }
}
