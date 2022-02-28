using CreditApplicationApi.Models;
using CreditApplicationApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditApplicationController : Controller
    {
        private readonly CreditService _creditService;

        public CreditApplicationController(CreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpPost]
        public IActionResult GetDecision(CreditApplication creditApplication)
        {
            try
            {
                CreditDecision creditDecision = _creditService.GetDecision(creditApplication);
                return Ok(creditDecision);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
