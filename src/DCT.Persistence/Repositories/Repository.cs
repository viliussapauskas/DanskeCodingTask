using DCT.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DCT.Persistence.Shared;

namespace DCT.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        //TODO: Should inject additional layer that decides which DataStorage to use
        protected readonly DCT_DbContext _dbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DCT_DbContext context)
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