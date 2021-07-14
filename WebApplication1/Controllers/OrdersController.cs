using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderBL _iOrdersBL;
        IMapper _mapper;

        public OrdersController(IOrderBL iOrdersBL, IMapper mapper)
        {
            _iOrdersBL = iOrdersBL;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<OrdersDTO>>> Get(int id)
        {
            List<Orders> orders = await _iOrdersBL.getOrders(id);
            if (orders == null)
                return NoContent();
            List<OrdersDTO> ordersDTO= _mapper.Map<List<Orders>, List<OrdersDTO>>(orders);
            return Ok(ordersDTO);
            // POST api/<OrdersController>
        }

        [HttpPost]
        public async Task<Orders> Post( Orders orders)
        {
            return await _iOrdersBL.PostOrders(orders);
        }
    }
}
