using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IProductBL
    {
        Task<List<Product>> getProduct();
        Task<List<Product>> getProduct(int id);
    }
}