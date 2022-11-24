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
    public class BranchOperationsController : ControllerBase
    {
        IBranchOperationService _branchOperationService;

        public BranchOperationsController(IBranchOperationService branchOperationService)
        {
            _branchOperationService = branchOperationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _branchOperationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        //api/branchoperations/getallbydoctorid?doctorid=1
        [HttpGet("getallbydoctorid")]
        public IActionResult GetAllByDoctorId(int doctorid)
        {
            var result = _branchOperationService.GetAllByDoctorId(doctorid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //api/doctors/getallbylanguageid?languageid=1
        [HttpGet("getallbybranchid")]
        public IActionResult GetAllByLanguageId(int branchid)
        {
            var result = _branchOperationService.GetAllByBranchId(branchid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //dto lu ver için
        [HttpGet("getbranchoperationdetails")]
        public IActionResult GetLanguageOperationDetails()
        {
            var result = _branchOperationService.GetBranchOperationDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbydoctoriddetails")]
        public IActionResult GetAllByDoctorIdDetails(int doctorid)
        {
            var result = _branchOperationService.GetAllByDoctorIdDetails(doctorid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(BranchOperation branchOperation)
        {
            var result = _branchOperationService.Add(branchOperation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(BranchOperation branchOperation)
        {
            var result = _branchOperationService.Update(branchOperation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(BranchOperation branchOperation)
        {
            var result = _branchOperationService.Delete(branchOperation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
