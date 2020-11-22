using DCT.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace DCT.Persistence.Repositories.Interfaces
{
    public interface IMunicipalityRepository : IRepository<DbContext ,Municipality>
    {
    }
}
