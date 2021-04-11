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
    public class RentalController:ControllerBase
    {
        IRentalService _rentalService;
        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getrentaldetails")]
        public IActionResult RentalDetails()
        {
            var result = _rentalService.GetRentalDetails();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getrentalbycarId")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _rentalService.GetByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getrentalbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _rentalService.GetByCustomerId(customerId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("deleterental")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("rentalcontrol")]
        public IActionResult RentalControl(int carId)
        {
            var result = _rentalService.RentalControl(carId);
            if (result.Success==true)
            {
                return Ok(result);
                
            }
            return BadRequest(result);


        }
    }
}
