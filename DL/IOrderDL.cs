using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IOrderDL
    {
        Task<List<Orders>> getOrders(int id);
        Task<Orders> PostOrders(Orders value);
    }
}