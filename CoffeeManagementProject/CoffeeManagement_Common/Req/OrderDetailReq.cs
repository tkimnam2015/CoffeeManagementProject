using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeManagement.Common.Req
{
    public class OrderDetailReq
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}