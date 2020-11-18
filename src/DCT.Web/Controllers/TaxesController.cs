using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DCT.Web.Controllers
{
    public class TaxesController : BaseController
    {
        private readonly ILogger<TaxesController> _logger;

        public TaxesController(ILogger<TaxesController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> GetTaxes()
        {
            return Ok("test");
        }
    }
}
