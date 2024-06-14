using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Orderid { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
