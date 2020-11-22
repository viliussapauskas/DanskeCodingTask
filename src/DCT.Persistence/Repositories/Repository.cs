using DCT.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DCT.Persistence.Shared;

namespace DCT.Persistence.Repositories
{
    public class Repository<TContext, TEntity> : IRepository<TContext, TEntity> 
        where TContext: DbContext
        where TEntity : Entity
    {
        private readonly TContext _dbContext;
        private readonly DbSet<TEntity> DbSet;

        public Repository(TContext context)
        {
            _dbContext = context;
            DbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            try
            {
                return await Task.FromResult(DbSet);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities in GetAll: {ex.Message}");
            }
        }
        public async Task<TEntity>GetById(int id)
        {
            try
            {
                return await Task.FromResult(DbSet.AsTracking().SingleOrDefault(x => x.Id == id));
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities in GetById: {ex.Message}");
            }
        }
    }
}