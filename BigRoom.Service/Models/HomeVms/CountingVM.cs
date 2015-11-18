using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigRoom.Service.Models.HomeVms
{
    public class CountingVM
    {
        public int ReviewCount { get; set; }
        public int ProductCount { get; set; }
        public int UserCount { get; set; }
        public int OrderCount { get; set; }
    }
}