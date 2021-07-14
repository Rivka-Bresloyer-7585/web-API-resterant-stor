using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductBL : IProductBL
    {
        IProductDL _productDL;
        public ProductBL(IProductDL product)
        {
            _productDL = product;
        }

        public async Task<List<Product>> getProduct()
        {
            return await _productDL.getProduct();
        }
        public async Task<List<Product>> getProduct(int id)
        {
            return await _productDL.getProduct(id);
        }
    }
}
