using System.Linq;
using System.Threading.Tasks;

namespace DCT.Persistence.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<IQueryable<TEntity>> GetAll();
    }
}
