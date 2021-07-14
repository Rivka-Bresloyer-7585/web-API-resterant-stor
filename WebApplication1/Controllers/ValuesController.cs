using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IuserBL _iuserBL;
        ILogger<ValuesController> _logger;

        public ValuesController(IuserBL iuserBL, ILogger<ValuesController> logger)
        {
            _iuserBL = iuserBL;
            _logger = logger;
        }

        [HttpGet("{name}/{pswd}")]
        public async Task<ActionResult< User>> Get(string name,string pswd)
        {
            //throw new Exception("\n error!!!\n");
            User user = await _iuserBL.getUser(name, pswd);
            if (user == null)
                return NoContent();
            _logger.LogInformation("\n USER: {0} PASSWORD: {1} CONNECTED\n",name,pswd);
            return Ok(user);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post( User value)
        {
            await _iuserBL.postUser(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userUpdate)
        {
           await _iuserBL.putUser(id, userUpdate);
        }

    }
}
