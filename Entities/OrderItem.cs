using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities‏
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int? Quantity { get; set; }

        [JsonIgnore]
        public virtual Orders Order { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
