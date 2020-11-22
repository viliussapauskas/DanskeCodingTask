using DCT.Persistence.Entities;
using DCT.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DCT.Persistence.Repositories
{
    public class MunicipalityRepository<TContext> : Repository<TContext,Municipality>, IMunicipalityRepository 
        where TContext: DbContext
    {
        public MunicipalityRepository(TContext context) : base(context)
        {
        }
    }
}
