using DCT.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DCT.Application.Services.Interfaces
{
    public interface IMunicipalityService
    {
        Task<List<MunicipalityDTO>> GetAll();
    }
}
