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
    public class CreditCardController : ControllerBase
    {
        ICreditCardService _creditCardService;
        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost("addcreditcard")]
        public IActionResult Add(CreditCard card)
        {
            var result = _creditCardService.Add(card);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _creditCardService.GetByCustomerId(customerId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);

        }
    }
}
