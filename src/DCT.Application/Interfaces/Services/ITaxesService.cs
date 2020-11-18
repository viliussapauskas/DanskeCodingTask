using System;
using System.Threading.Tasks;

namespace DCT.Application.Interfaces.Services
{
    public interface ITaxesService
    {
        Task<double> GetTaxes(int municipalityId, DateTime date);
    }
}
