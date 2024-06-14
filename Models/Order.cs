using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class Order
    {
        public Order()
        {
            Carts = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Userid { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
