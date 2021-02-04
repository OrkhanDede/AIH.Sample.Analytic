using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIH.ERP.Analytic.API.Models
{
    /// <summary>
    /// Post expense
    /// </summary>
    public class PostExpenseData
    {
        /// <summary>
        /// Company Id
        /// </summary>
        [Required]
        public int CompanyId { get; set; }
        /// <summary>
        /// Date of Expense
        /// </summary>
        [Required]
        public DateTime DateOfExpense { get; set; }
        /// <summary>
        /// Money
        /// </summary>
        [Required]
        public decimal Money { get; set; }
    }
}
