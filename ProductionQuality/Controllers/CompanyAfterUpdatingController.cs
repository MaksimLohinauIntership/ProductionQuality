using Microsoft.AspNetCore.Mvc;
using ProductionQuality.Models;
using ProductionQuality.Server.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductionQuality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyAfterUpdatingController : ControllerBase
    {
        private readonly ICompnayService _companyService;
        public CompanyAfterUpdatingController(ICompnayService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [SwaggerOperation("Get price after updating")]
        public async Task<IActionResult> GetPriceHistoryAfterUpdating(int companyId)
        {
            if (companyId < 0)
                throw new Exception("Not correct company Id");

            var prices = await _companyService.GetPricesAfterUpdating(companyId);

            return Ok(prices);

        }

        [HttpPost]
        [SwaggerOperation("Add price after updating")]
        public async Task<IActionResult> AddPriceAfterUpdatingRequirements([FromQuery] PriceInformation information, int companyId)
        {
            if (companyId < 0)
                throw new ArgumentNullException("Company id can't be lass than 0");

            Server.Models.PriceInformation model = new Server.Models.PriceInformation();
            model.Price = information.Price;
            model.Date = information.Date;

            await _companyService.AddHistoryPriceAfterUpdatingRequirements(model, companyId);

            return NoContent();
        }
    }
}
