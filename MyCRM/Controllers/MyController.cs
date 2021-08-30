using CRM.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        public readonly IJwtAuthenticationManager jwtauthenticationmanager;

        public MyController(IJwtAuthenticationManager  jwtauthenticationmanager)
        {
            this.jwtauthenticationmanager = jwtauthenticationmanager;
        }
        // GET: api/<MyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "new jersey", "new york" };
        }

        // GET api/<MyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
           var token = jwtauthenticationmanager.Authenticate(userCred.username, userCred.password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

    }
}
