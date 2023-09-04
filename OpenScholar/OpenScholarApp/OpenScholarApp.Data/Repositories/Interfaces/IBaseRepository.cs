using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entity);
        Task Remove(T entity);
        Task RemoveEntirely(T entity);
        Task RemoveRange(IEnumerable<T> entity);
        Task Update(T entity);
        Task UpdateRange(IEnumerable<T> entity);
        Task<T> GetByIdInt(int id);
        Task<T> GetById(string id);
        Task<List<T>> GetAll();
        Task SaveChanges();
    }
}
