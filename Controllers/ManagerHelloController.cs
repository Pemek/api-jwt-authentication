using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_jwt_authentication.Controllers
{
    [Authorize(Policy = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerHelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"Hello from ManagerController to {User.FindFirst(ClaimTypes.Email).Value} with role {User.FindFirst(ClaimTypes.Role).Value}");
        }
    }
}