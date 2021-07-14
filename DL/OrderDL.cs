using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class OrderDL : IOrderDL
    {
        ApiDBContext _db;
        public OrderDL(ApiDBContext api_DataBaseContext)
        {
            _db = api_DataBaseContext;
        }

        public async Task<List<Orders>> getOrders(int id)
        {
            List<Orders> orders = await _db.Orders.Where(c => c.OrderId == id).ToListAsync();
            return orders;
        }

        public async Task<Orders> PostOrders(Orders value)
        {
            await _db.Orders.AddAsync(value);
            await _db.SaveChangesAsync();
            return value;
        }
    }
}

