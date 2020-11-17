using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DCT.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxesController : ControllerBase
    {
        private readonly ILogger<TaxesController> _logger;

        public TaxesController(ILogger<TaxesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<int> Get()
        {
            return new List<int>();
        }
    }
}
