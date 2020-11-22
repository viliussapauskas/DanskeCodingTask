using DCT.Application.Models;
using System.Threading.Tasks;

namespace DCT.Application.Services.Interfaces
{
    public interface ITaxesService
    {
        Task<double> GetTaxes(GetCalculatedTaxesDTO request);
    }
}
