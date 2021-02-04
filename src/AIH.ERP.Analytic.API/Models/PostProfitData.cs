using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIH.ERP.Analytic.API.Models
{
    public class PostProfitData
    {
        /// <summary>
        /// Company Id
        /// </summary>
        [Required]
        public int CompanyId { get; set; }
        /// <summary>
        /// Date of Profit
        /// </summary>
        [Required]
        public DateTime DateOfProfit { get; set; }
        /// <summary>
        /// Money
        /// </summary>
        [Required]
        public decimal Money { get; set; }
    }
}
