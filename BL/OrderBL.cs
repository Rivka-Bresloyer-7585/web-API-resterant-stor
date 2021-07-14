using DL;
using Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrderBL : IOrderBL
    {
        IOrderDL _ordersDL;
        ApiDBContext _db;
        ILogger<OrderBL> _logger;
        public OrderBL(IOrderDL orders, ILogger<OrderBL> logger, ApiDBContext apiDBContext)
        {
            _ordersDL = orders;
            _logger = logger;
            _db = apiDBContext;
        }
        public async Task<List<Orders>> getOrders(int id)
        {
            return await _ordersDL.getOrders(id);
        }

        public async Task<Orders> PostOrders(Orders order)
        {
            int sum = 0;
            foreach (var product in order.OrderItem)
            {
                Product p = await _db.Product.FindAsync(product.ProductId);
                sum += (int)product.Quantity * (int)p.Price;
            }
            if (order.OrderSum != sum)
            {
                _logger.LogInformation("\nPay attention!!!, the order sum were changed, check why...\n");
                order.OrderSum = sum;
            }
            return await _ordersDL.PostOrders(order);

        }
    }
}

//public async Task<Orders> PostOrder(Orders orderToInsert)
//{
//    int sum = 0;
//    foreach (var item in orderToInsert.OrderItem)
//    {

//        ProductTbl p = await _productDL.GetProductByID(item.ProductsId);
//        sum += p.Price;

//    }
//    if (orderToInsert.OrderSum != sum)
//        _logger.LogInformation("pay attention!!! mismatch in the sum that come from client to the real sum");


//    orderToInsert.OrderSum = sum;

//    Orders o = await _orderDl.PostOrder(orderToInsert);
//    return o;
//}


//    }

