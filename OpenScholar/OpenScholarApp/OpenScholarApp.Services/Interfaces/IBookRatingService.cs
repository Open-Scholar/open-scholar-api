using OpenScholarApp.Dtos.BookRatingDto;
using OpenScholarApp.Dtos.BookSellerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookRatingService
    {
        Task<List<BookRatingDto>> GetAll();
        Task<BookRatingDto> GetById(int id);
        Task Add(AddBookRatingDto addDto, string userId);
        Task Update(UpdateBookRatingDto updateDto);
        Task Delete(int id);
    }
}
