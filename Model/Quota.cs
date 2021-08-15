using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCredit.API.Model
{
    public class Quota
    {
        public decimal? Value { get; set; }
        public int quota { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Total { get; set; }
    }
}
