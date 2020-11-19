using DCT.Application.Models;
using DCT.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DCT.Web.Controllers
{
    public class MunicipalityController : BaseController
    {
        private readonly IMunicipalityService _municipalityService;

        public MunicipalityController(IMunicipalityService municipalityService)
        {
            _municipalityService = municipalityService;
        }

        [HttpGet]
        public async Task<List<MunicipalityDTO>> GetAll()
        {
            return await _municipalityService.GetAll();
        }
    }
}
