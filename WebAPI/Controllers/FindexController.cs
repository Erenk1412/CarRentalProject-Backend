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
    public class FindexController:ControllerBase
    {
        IFindexService _findexService;
        public FindexController(IFindexService findexService)
        {
            _findexService = findexService;
        }
       
        [HttpGet("getuserfindex")]
        public IActionResult GetFindexByUserId(int userId)
        {
            var result = _findexService.GetFindexByUserId(userId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
