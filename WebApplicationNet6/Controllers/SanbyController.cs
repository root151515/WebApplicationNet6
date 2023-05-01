using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNet6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SanbyController : ControllerBase
    {
        [HttpGet("GetSanbyData")]
        public IActionResult GetSanbyData()
        {
            return Ok(123);
        }
    }
}
