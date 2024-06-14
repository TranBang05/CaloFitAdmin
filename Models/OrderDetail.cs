using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Orderid { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Ingredient Product { get; set; } = null!;
    }
}
