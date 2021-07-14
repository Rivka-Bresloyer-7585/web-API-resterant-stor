using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        ICatagoryBL _catagoryBL;

        public CatagoryController(ICatagoryBL catagory)
        {
            _catagoryBL = catagory;
        }

        // GET: api/<CatagoryController1>
        [HttpGet]
        public async Task<ActionResult<List<Catagory>>> Get()
        {
            List<Catagory> catagory = await _catagoryBL.getCatagory();
            if (catagory == null)
                return NoContent();
            return Ok(catagory);
        }

        // GET api/<CatagoryController1>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Catagory>>> Get(int id)
        {
            List<Catagory> catagory = await _catagoryBL.getCatagory(id);
            if (catagory == null)
                return NoContent();
            return Ok(catagory);
        }

    }
}
