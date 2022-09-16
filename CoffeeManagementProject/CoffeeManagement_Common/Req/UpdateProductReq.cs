using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeManagement.Common.Req
{
    public class UpdateProductReq
    {
        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public string ProductName { get; set; }
    }
}