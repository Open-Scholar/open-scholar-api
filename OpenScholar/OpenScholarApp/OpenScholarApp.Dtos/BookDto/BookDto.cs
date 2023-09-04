using OpenScholarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Dtos.BookDto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ReleaseDate { get; set; }
        public string? Description { get; set; }
        public List<Author> Authors { get; set; }
        //public List<int> AuthorId { get; set; }
    }
}
