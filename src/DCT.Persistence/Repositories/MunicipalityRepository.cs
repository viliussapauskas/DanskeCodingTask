using DCT.Persistence.Entities;
using DCT.Persistence.Repositories.Interfaces;

namespace DCT.Persistence.Repositories
{
    public class MunicipalityRepository : Repository<Municipality>, IMunicipalityRepository
    {
        public MunicipalityRepository(DCT_DbContext context) : base(context)
        {
        }
    }
}
