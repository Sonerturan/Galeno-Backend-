using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _languageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
