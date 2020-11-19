using System;
using System.Threading.Tasks;

namespace DCT.Application.Services.Interfaces
{
    public interface ITaxesService
    {
        Task<double> GetTaxes(int municipalityId, DateTime date);
    }
}
