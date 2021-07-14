using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IOrderBL
    {
        Task<List<Orders>> getOrders(int id);
        Task<Orders> PostOrders(Orders order);
    }
}