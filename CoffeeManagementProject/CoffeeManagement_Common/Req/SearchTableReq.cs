using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeManagement.Common.Req
{
    public class SearchTableReq
    {
        public int Capacity { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}