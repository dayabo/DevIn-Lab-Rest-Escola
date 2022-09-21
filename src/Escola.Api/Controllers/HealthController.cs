using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {

        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult Health (){
            return Ok("Health");
        }
    }
}