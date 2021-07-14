using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IProductDL
    {
        Task<List<Product>> getProduct();
        Task<List<Product>> getProduct(int id);
    }
}