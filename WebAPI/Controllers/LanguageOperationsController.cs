using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageOperationsController : ControllerBase
    {
        ILanguageOperationService _languageOperationService;

        public LanguageOperationsController(ILanguageOperationService languageOperationService)
        {
            _languageOperationService = languageOperationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _languageOperationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
       

        //api/languageoperations/getallbydoctorid?doctorid=1
        [HttpGet("getallbydoctorid")]
        public IActionResult GetAllByDoctorId(int doctorid)
        {
            var result = _languageOperationService.GetAllByDoctorId(doctorid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //api/doctors/getallbylanguageid?languageid=1
        [HttpGet("getallbylanguageid")]
        public IActionResult GetAllByLanguageId(int languageid)
        {
            var result = _languageOperationService.GetAllByLanguageId(languageid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //dto lu ver için
        [HttpGet("getlanguageoperationdetails")]
        public IActionResult GetLanguageOperationDetails()
        {
            var result = _languageOperationService.GetLanguageOperationDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbydoctoriddetails")]
        public IActionResult GetAllByDoctorIdDetails(int doctorid)
        {
            var result = _languageOperationService.GetAllByDoctorIdDetails(doctorid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(LanguageOperation languageOperation)
        {
            var result = _languageOperationService.Add(languageOperation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(LanguageOperation languageOperation)
        {
            var result = _languageOperationService.Update(languageOperation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(LanguageOperation languageOperation)
        {
            var result = _languageOperationService.Delete(languageOperation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
