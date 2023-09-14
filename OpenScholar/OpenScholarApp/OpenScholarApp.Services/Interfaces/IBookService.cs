using OpenScholarApp.Dtos.BookDto;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAll();
        Task<BookDto> GetById(int id);
        Task Add(AddBookDto addDto, string userId);
        Task Update(UpdateBookDto updateDto);
        Task Delete(int id);
    }

}
