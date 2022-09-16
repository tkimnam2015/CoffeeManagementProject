using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeManagement.Common.Req
{
    public class RevenueReq
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int ProductId { get; set; }
    }
}