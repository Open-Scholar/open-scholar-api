using OpenScholarApp.Dtos.BookStoreDto;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookStoreService
    {
        Task<List<BookStoreDto>> GetAll();
        Task<BookStoreDto> GetById(int id);
        Task Add(AddBookStoreDto addDto, string userId);
        Task Update(UpdateBookStoreDto updateDto);
        Task Delete(int id);
    }
}
