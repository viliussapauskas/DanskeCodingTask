using DCT.Application.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace DCT.Application.Services
{
    public class TaxesService: ITaxesService
    {
        public async Task<double> GetTaxes(int municipalityId, DateTime date)
        {
            return municipalityId;
        }
    }
}
