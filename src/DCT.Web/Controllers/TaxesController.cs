using System;
using System.Threading.Tasks;
using DCT.Application.Models;
using DCT.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DCT.Web.Controllers
{
    public class TaxesController : BaseController
    {
        private readonly ILogger<TaxesController> _logger; // TODO
        private readonly ITaxesService _taxesService;

        public TaxesController(ILogger<TaxesController> logger, ITaxesService taxesService)
        {
            _logger = logger;
            _taxesService = taxesService;
        }

        [HttpGet]
        public async Task<double> GetTaxes([FromQuery] GetCalculatedTaxesDTO query)
        {
            return await _taxesService.GetTaxes(query);
        }
    }
}
