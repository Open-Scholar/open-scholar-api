using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Shared.CustomExceptions.BookException
{
    public class BookDataException : Exception
    {
        public BookDataException(string message) : base(message) { }
    }
}
