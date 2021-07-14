using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        [JsonIgnore]
        public virtual Catagory Category { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
