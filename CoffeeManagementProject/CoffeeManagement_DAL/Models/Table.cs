using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeeManagement.DAL.Models
{
    public partial class Table
    {
        public Table()
        {
            Orders = new HashSet<Order>();
        }

        public int TableId { get; set; }
        public string TableName { get; set; }
        public bool? Active { get; set; }
        public int? Capacity { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}