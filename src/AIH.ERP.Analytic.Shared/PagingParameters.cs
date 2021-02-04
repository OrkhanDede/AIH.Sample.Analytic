using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIH.ERP.Analytic.Shared
{
    public class PagingParameters
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 25;
    }
}
