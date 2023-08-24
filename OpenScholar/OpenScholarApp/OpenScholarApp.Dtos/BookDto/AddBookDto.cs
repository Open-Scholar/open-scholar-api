using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Dtos.BookDto
{
    public class AddBookDto
    {
        public string Title { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; }
        public string? Description { get; set; }
        public ICollection<string> Authors { get; set; }
        public List<int> AuthorId { get; set; }
    }
}
