using BookYourShow.Api.Controllers;
using BookYourShow.Models;
using BookYourShow.Api.Repository;
using BookYourShow.Api.ViewModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookYourShow.Api.Test.MockData
{
    public class LanguagesMockData
    {
        #region LanguageTest
        public static async Task<List<Languages>> GetLanguages()
        {
            var _language = new List<Languages>()
            {
                new Languages()
                {
                    LangId =12,
                    Language = "English"
                }
            };
            return _language;
        }
        public static Mock<ILanguageRepository> AddLanguageTest()
        {
            var languages = new List<Languages>()
            {
                new Languages()
                {
                   LangId = 5,
                   Language = "French"
                },
                new Languages()
                {
                   LangId = 6,
                   Language = "Thai"
                }
            };

            var mockRepo = new Mock<ILanguageRepository>();
            mockRepo.Setup(r => r.AddLanguage(It.IsAny<Languages>())).ReturnsAsync((Languages language) =>
            {
                languages.Add(language);
                return language;
            });
            return mockRepo;
        }
        public static Mock<ILanguageRepository> DeleteLanguageMock()
        {
            var languages = new Languages()
            {
                LangId = 6,
                Language = "Thai"
            };
            var mockRepo = new Mock<ILanguageRepository>();
            mockRepo.Setup(r => r.DeleteLanguage(6)).ReturnsAsync(languages);
            return mockRepo;
        }
        #endregion

    }
}
