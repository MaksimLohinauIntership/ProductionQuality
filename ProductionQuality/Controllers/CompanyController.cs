using Microsoft.AspNetCore.Mvc;
using ProductionQuality.Models;
using ProductionQuality.Server.Interfaces;
using Swashbuckle.AspNetCore.Annotations;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductionQuality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompnayService _companyService;
        public CompanyController(ICompnayService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [SwaggerOperation("Add price")]
        public async Task<IActionResult> AddPrice([FromQuery]Company company)
        {
            if (company == null)
                throw new ArgumentNullException("Not found");

            await _companyService.AddPriceHistory(company.Id, company.Price);

            return NoContent();
        }

        [HttpGet]
        [SwaggerOperation("Get price history")]
        public async Task<IActionResult> GetPriceHistory(int companyId)
        {
            if(companyId < 0) 
                throw new Exception("Not correct company Id");

            var prices = await _companyService.GetPricesAfterUpdating(companyId);

            return Ok(prices);

        }
    }
}
