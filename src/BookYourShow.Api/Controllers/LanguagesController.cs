using BookYourShow.Models;
using BookYourShow.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Controllers
{
    [Route("languages")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        ILanguageRepository languageRepository;
        public LanguagesController(ILanguageRepository _p)
        {
            languageRepository = _p;
        }

        #region get languages
        [HttpGet]
        [ProducesResponseType(typeof(Languages), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetLanguages()
        {
            var languages = await languageRepository.GetLanguages();
            if (languages == null)
            {
                return NotFound();
            }
            return Ok(languages);
        }
        #endregion

        #region add language
        [HttpPost]
        [ProducesResponseType(typeof(Languages), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddLanguage([FromBody] Languages language)
        {
            if (ModelState.IsValid)
            {
                var langId = await languageRepository.AddLanguage(language);
                if (langId != null)
                {
                    return Ok(langId);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        #endregion

        #region delete Language
        [HttpDelete]
        [ProducesResponseType(typeof(Languages), 200)]
        [ProducesResponseType(404)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            var exp = await languageRepository.DeleteLanguage(id);
            if (exp == null)
            {
                return NotFound();
            }
            return Ok(exp);
        }
        #endregion
    }
}
