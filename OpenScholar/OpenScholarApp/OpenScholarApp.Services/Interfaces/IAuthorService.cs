using OpenScholarApp.Dtos.AuthorDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<Response<List<AuthorDto>>> GetAllAuthorsAsync();
        Task<Response<AuthorDto>> GetAuthorByIdAsync(int id);
        Task<Response> CreateAuthorAsync(AddAuthorDto addDto, string userId);
        Task<Response> UpdateAuthorAsync(int id, UpdateAuthorDto updateDto, string userId);
        Task<Response> DeleteAuthorAsync(int id, string userId);
    }
}
