using Demo.DAL.DbContexts;
using Demo.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public Repository(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<Repository<TEntity>>();
        }
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(params Expression<Func<TEntity, dynamic>>[] includePaths)
        {
            var q=_context.Set<TEntity>().AsNoTracking();
            q = includePaths.Aggregate(q, (current, path) =>  current.Include(path));
            return q.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, dynamic>>[] includePaths)
        {
            var q = _context.Set<TEntity>().AsNoTracking().Where(predicate);
            q = includePaths.Aggregate(q, (current, path) => current.Include(path));
            return q.ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(params Expression<Func<TEntity, dynamic>>[] includePaths)
        {
            var query = _context.Set<TEntity>().AsNoTracking();
            query = includePaths.Aggregate(query, (current, path) => current.Include(path));
            return await query.ToListAsync();
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, dynamic>>[] includePaths)
        {
            throw new NotImplementedException();
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, dynamic>>[] includePaths)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, dynamic>>[] includePaths)
        {
            var query = _context.Set<TEntity>().AsNoTracking().Where(predicate);
            query = includePaths.Aggregate(query, (current, path) => current.Include(path));
            return await query.FirstOrDefaultAsync();
        }

        public int Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Insert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            try
            {
                if (entity==null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                var set = _context.Set<TEntity>();
                _context.Update(set);
               
            }
            catch (Exception ex)
            {

                _logger.LogError(new EventId(), ex, ex.Message);
            }
            return _context.SaveChanges();
        }

        public int Update(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
