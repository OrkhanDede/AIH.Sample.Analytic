using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIH.ERP.Analytic.API.Models;
using AIH.ERP.Analytic.Application.Services;
using AIH.ERP.Analytic.Domain.Entities;
using AIH.ERP.Analytic.Domain.Enums;
using AIH.ERP.Analytic.Shared;
using Microsoft.Extensions.Logging;

namespace AIH.ERP.Analytic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICompanyService _companyService;
        /// <summary>
        /// Analytic of companies data
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="companyService"></param>
        public CompanyController(ILogger<WeatherForecastController> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }
        /// <summary>
        /// Get all companies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var companies = await _companyService.GetAllCompanyAsync();
            return Ok(companies);
        }
        /// <summary>
        /// Post profit data to company
        /// </summary>
        /// <returns></returns>
        [HttpPost("profit")]
        public async Task<IActionResult> PostProfit([FromBody] PostProfitData profitData)
        {
            bool hasAnyCompany = await _companyService.HasCompanyByIdAsync(profitData.CompanyId);
            if (!hasAnyCompany)
            {
                return BadRequest("wrong request,company not found");
            }
            Profit profit = new Profit()
            {
                DateOfProfit = profitData.DateOfProfit,
                Money = profitData.Money,
                Status = RecordStatus.Active,
                CompanyId = profitData.CompanyId
            };
            await _companyService.AddProfitToCompanyAsync(profit);
            return Ok();
        }
        /// <summary>
        /// Post expense data to company
        /// </summary>
        /// <param name="expenseData"></param>
        /// <returns></returns>
        [HttpPost("expense")]
        public async Task<IActionResult> PostExpense([FromBody] PostExpenseData expenseData)
        {
            bool hasAnyCompany = await _companyService.HasCompanyByIdAsync(expenseData.CompanyId);
            if (!hasAnyCompany)
            {
                return BadRequest("wrong request,company not found");
            }
            Expense expense = new Expense()
            {
                DateOfExpense = expenseData.DateOfExpense,
                Money = expenseData.Money,
                Status = RecordStatus.Active,
                CompanyId = expenseData.CompanyId
            };
            await _companyService.AddExpenseToCompanyAsync(expense);
            return Ok();
        }
        /// <summary>
        /// Get analytic data by company id and year range
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("analytic")]
        public async Task<List<AnalyticData>> GetAsync([FromQuery] AnalyticFilter model)
        {
            //if(!ModelState.IsValid) return new BadRequestObjectResult(ModelState);

            var dataFiltered = await _companyService
                .GetAnalyticDataAsync(model.Id, model.YearFrom, model.YearTo);
            return dataFiltered;
        }
    }
}
