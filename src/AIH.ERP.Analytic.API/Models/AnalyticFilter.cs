using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIH.ERP.Analytic.API.Models
{
    public class AnalyticFilter
    {
        /// <summary>
        /// CompanyId
        /// </summary>
        [Required]
        public List<long> Ids { get; set; }
        
        [Required]
        public int YearFrom { get; set; }
      
        [Required]
        public int YearTo { get; set; }
    }
}
