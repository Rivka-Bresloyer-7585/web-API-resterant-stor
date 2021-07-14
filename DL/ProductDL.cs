using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ProductDL : IProductDL
    {

        ApiDBContext _db;
        public ProductDL(ApiDBContext apiDBContext)
        {
            _db = apiDBContext;
        }

        public async Task<List<Product>> getProduct()
        {
            List<Product> products = await _db.Product.ToListAsync();
            return products;
        }

        public async Task<List<Product>> getProduct(int id)
        {
            return await _db.Product.Where(c => c.CategoryId == id).ToListAsync();
        }
    }
}
