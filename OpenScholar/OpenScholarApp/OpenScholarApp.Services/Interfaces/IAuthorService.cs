using OpenScholarApp.Dtos.AuthorDto;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAll();
        Task<AuthorDto> GetById(int id);
        Task Add(AddAuthorDto addDto, string userId);
        Task Update(UpdateAuthorDto updateDto);
        Task Delete(int id);
    }
}
