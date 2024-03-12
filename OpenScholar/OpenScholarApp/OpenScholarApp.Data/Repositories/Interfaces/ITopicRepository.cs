using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface ITopicRepository : IBaseRepository<Topic>
    {
        Task<List<Topic>> GetAllWithUserAndLikesAsync();
        Task<Topic> GetByIdWithLikesAsync(int id);
        Task<(IEnumerable<Topic> Items, int TotalCount)> GetAllWithUserAndFiltersAsync(int? facultyId = null,
                                                                                        int? universityId = null,
                                                                                        bool? isMostPopular = false,
                                                                                        bool? isUserPost = false,
                                                                                        int pageNumber = 1,
                                                                                        int pageSize = 10);
    }
}
