using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_jwt_authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicHelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from PublicController to everyone");
        }
    }
}