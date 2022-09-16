using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System;

namespace CoffeeManagement.DAL
{
    public class OrderReq
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public int? TableId { get; set; }
    }
}