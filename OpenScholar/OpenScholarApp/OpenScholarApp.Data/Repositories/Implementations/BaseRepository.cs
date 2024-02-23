using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public BaseRepository(OpenScholarDbContext openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<(IEnumerable<T> Items, int TotalCount)> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            try
            {
                var query = _openScholarDbContext.Set<T>().AsQueryable();

                var totalCount = await query.CountAsync();

                var items = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return (items, totalCount);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Add(T entity)
        {
            try
            {
                _openScholarDbContext.Set<T>().Add(entity);
                await _openScholarDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddRange(IEnumerable<T> entity)
        {
            try
            {
                _openScholarDbContext.Set<T>().AddRange(entity);
                await _openScholarDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateRange(IEnumerable<T> entity)
        {
            try
            {
                _openScholarDbContext.Set<T>().UpdateRange(entity);
                await _openScholarDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                List<T> getAll = await _openScholarDbContext.Set<T>().ToListAsync();
                return getAll;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetById(string id)
        {
            try
            {
                return _openScholarDbContext.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetByIdInt(int id)
        {
            try
            {
                return _openScholarDbContext.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Remove(T entity)
        {
            try
            {
                _openScholarDbContext.Entry(entity).State = EntityState.Modified;
                await _openScholarDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RemoveEntirely(T entity)
        {
            try
            {
                _openScholarDbContext.Remove(entity);
                await _openScholarDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RemoveRange(IEnumerable<T> entity)
        {
            try
            {
                _openScholarDbContext.Set<T>().RemoveRange(entity);
                await _openScholarDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SaveChanges()
        {
            try
            {
                await _openScholarDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                _openScholarDbContext.Set<T>().Update(entity);
                await _openScholarDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

