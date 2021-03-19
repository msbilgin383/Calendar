using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        IPlanService _planService;

        public PlansController(IPlanService productService)
        {
            _planService = productService;
        }
        [HttpGet("getall")]
        //[Authorize(Roles = "Product.List")]
        public IActionResult GetAll()
        {

            var result = _planService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Plan plan)
        {
            var result = _planService.Add(plan);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Plan plan)
        {
            var result = _planService.Update(plan);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Plan plan)
        {
            var result = _planService.Delete(plan);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpGet("getactiveplans")]
        public IActionResult GetActivePlans()
        {

            var result = _planService.GetActivePlans();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
