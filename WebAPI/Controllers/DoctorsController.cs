using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(500);
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _doctorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        //api/doctors/getbyid?id=1
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _doctorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //api/doctors/getallbycityid?cityid=1
        [HttpGet("getallbycityid")]
        public IActionResult GetAllByCityId(int cityid)
        {
            var result = _doctorService.GetAllByCityId(cityid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //dto lu ver için
        [HttpGet("getdoctordetails")]
        public IActionResult GetDoctorDetails()
        {
            var result = _doctorService.GetDoctorDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //dto lu ver için
        [HttpGet("getdoctorsearch")]
        public IActionResult GetDoctorSearch(string language, string branch, string city)
        {
            var result = _doctorService.GetDoctorSearch(language, branch, city);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Doctor doctor)
        {
            var result = _doctorService.Add(doctor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Doctor doctor)
        {
            var result = _doctorService.Update(doctor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Doctor doctor)
        {
            var result = _doctorService.Delete(doctor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
