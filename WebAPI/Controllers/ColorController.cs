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

        [HttpGet("getbyid")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _colorService.GetById(colorId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
