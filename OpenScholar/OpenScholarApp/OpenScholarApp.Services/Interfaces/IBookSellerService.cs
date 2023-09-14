using OpenScholarApp.Dtos.BookSellerDto;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookSellerService
    {
        Task<List<BookSellerDto>> GetAll();
        Task<BookSellerDto> GetById(int id);
        Task Add(AddBookSellerDto addDto, string userId);
        Task Update(UpdateBookSellerDto updateDto);
        Task Delete(int id);
    }
}
