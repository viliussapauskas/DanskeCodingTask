using System.Linq;
using System.Threading.Tasks;

namespace DCT.Persistence.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
    }
}
