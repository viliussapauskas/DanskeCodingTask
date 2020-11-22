using DCT.Persistence.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DCT.Persistence.Repositories.Interfaces
{
    public interface IRepository<TContext, TEntity>
        where TContext : DbContext
        where TEntity : Entity
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
    }
}
