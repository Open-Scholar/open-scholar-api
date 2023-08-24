using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.BookDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Mappers
{
    public static class BookMapper
    {
        public static BookDto ToBookDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                ReleaseDate = book.ReleaseDate,
                Description = book.Description,
                Authors = book.Authors,
                AuthorId = book.AuthorId,
            };
        }

        public static Book ToBook(this BookDto bookDto)
        {
            return new Book
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                ReleaseDate = bookDto.ReleaseDate,
                Description = bookDto.Description,
                Authors = bookDto.Authors,
                AuthorId = bookDto.AuthorId,
            };
        }
    }
}
