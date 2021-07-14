using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities‏
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderSum { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
