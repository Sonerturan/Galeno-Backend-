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
    public class InstitutionsController : ControllerBase
    {
        IInstitutionService _institutionService;

        public InstitutionsController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _institutionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
