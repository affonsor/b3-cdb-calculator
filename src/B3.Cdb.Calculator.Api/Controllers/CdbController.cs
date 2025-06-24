using B3.Cdb.Calculator.Application.Contracts;
using B3.Cdb.Calculator.Domain.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace B3.Cdb.Calculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CdbController(ICdbInvestmentService cdbInvestmentService) : ControllerBase
    {
        private readonly ICdbInvestmentService _cdbInvestmentService = cdbInvestmentService;

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] CdbInvestmentRequestDto request)
        {
            var response = _cdbInvestmentService.CalculateCdbInvestment(request);
            return StatusCode(response.StatusCode, response);
        }
    }
}