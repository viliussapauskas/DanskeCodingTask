using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DCT.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DCT.Web.Controllers
{
    public class TaxesController : BaseController
    {
        private readonly ILogger<TaxesController> _logger;
        private readonly ITaxesService _taxesService;

        public TaxesController(ILogger<TaxesController> logger, ITaxesService taxesService)
        {
            _logger = logger;
            _taxesService = taxesService;
        }

        public async Task<double> GetTaxes()
        {
            return await _taxesService.GetTaxes(1, DateTime.Now);
        }
    }
}
