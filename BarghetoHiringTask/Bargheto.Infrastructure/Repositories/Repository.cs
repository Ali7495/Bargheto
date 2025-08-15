using Bargheto.Domain.Interfaces.Repositories;
using Bargheto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BarghetoDbContext _dbContext;
        internal DbSet<TEntity> Entities;

        public Repository(BarghetoDbContext dbContext)
        {
            _dbContext = dbContext;
            Entities = _dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await Entities.AddAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Entities.Update(entity);
            await Task.CompletedTask;
        }

        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool hasTracking, CancellationToken cancellationToken = default)
        {
            if (hasTracking)
            {
                return await Entities.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
            }
            else
            {
                return await Entities.Where(predicate).ToListAsync(cancellationToken);
            }
        }

        public ValueTask<TEntity?> FindByKeyAsync(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return Entities.FindAsync(keyValues, cancellationToken);
        }

        public async Task<List<TEntity>> GetAllAsync(bool hasTracking, CancellationToken cancellationToken = default)
        {
            if (hasTracking)
            {
                return await Entities.AsNoTracking().ToListAsync(cancellationToken);
            }
            else
            {
                return await Entities.ToListAsync(cancellationToken);
            }
        } 

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await Entities.FindAsync(id, cancellationToken);
        }


        public async Task UpdateAsync(TEntity entity)
        {
            Entities.Update(entity);
            await Task.CompletedTask;
        }
    }
}
