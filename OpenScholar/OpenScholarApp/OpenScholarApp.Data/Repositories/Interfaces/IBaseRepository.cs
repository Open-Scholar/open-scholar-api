namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entity);
        Task<(IEnumerable<T> Items, int TotalCount)> GetAllPagedAsync(int pageNumber, int pageSize);
        Task Remove(T entity);
        Task RemoveEntirely(T entity);
        Task RemoveRange(IEnumerable<T> entity);
        Task Update(T entity);
        Task UpdateRange(IEnumerable<T> entity);
        Task<T> GetByIdInt(int id);
        Task<T> GetById(string id);
        Task<List<T>> GetAll();
        //Task<List<T>> GetAllWithUserAsync();
        Task SaveChanges();
    }
}
