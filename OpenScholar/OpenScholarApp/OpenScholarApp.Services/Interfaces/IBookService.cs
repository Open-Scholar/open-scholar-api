using Azure;
using OpenScholarApp.Dtos.BookDto;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookService
    {
        Task <Response<List<BookDto>>> GetAll();
        Task <Response<BookDto>> GetById(int id);
        Task <Response>Add(AddBookDto addDto, string userId);
        Task <Response>Update(UpdateBookDto updateDto);
        Task Delete(int id);
    }

}
