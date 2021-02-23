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
    public class ColorController:ControllerBase

    {
        IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }
        [HttpGet("getallcolors")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("colorsbyid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _colorService.GetById(3);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
