using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.AuthorDto;
using OpenScholarApp.Dtos.BookDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDto ToAuthorDto(this Author authorDb)
        {
            return new AuthorDto
            {
                FirstName = authorDb.FirstName,
                LastName = authorDb.LastName,
                EmailAdress = authorDb.EmailAdress,
                Description = authorDb.Description,
            };
        }

        public static Author ToAuthor(this AddAuthorDto addAuthorDto)
        {
            return new Author
            {
                FirstName = addAuthorDto.FirstName,
                LastName = addAuthorDto.LastName,
                EmailAdress = addAuthorDto.EmailAdress,
                Description = addAuthorDto.Description,
            };
        }
    }
}
