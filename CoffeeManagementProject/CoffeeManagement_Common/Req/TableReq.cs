using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeManagement.Common.Req
{
    public class TableReq
    {
        public int TableId { get; set; }
        public string TableName { get; set; }
        public bool? Active { get; set; }
        public int Capacity { get; set; }
    }
}