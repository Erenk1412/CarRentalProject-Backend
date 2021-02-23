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
    public class BrandController:ControllerBase
    {
        IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getallbrands")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
       [HttpGet("getbrandsbyid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _brandService.GetById(3);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
