using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Shared.CustomExceptions.BookRatingExceptions
{
    public class BookRatingNotFoundException : Exception
    {
        public BookRatingNotFoundException(string message):base(message) { }
    }
}
