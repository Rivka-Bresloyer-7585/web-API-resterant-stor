using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Catagory
    {
        public Catagory()
        {
            Product = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
