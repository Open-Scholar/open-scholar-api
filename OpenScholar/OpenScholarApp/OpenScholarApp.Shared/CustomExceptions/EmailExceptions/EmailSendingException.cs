using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Shared.CustomExceptions.EmailExceptions
{
    public class EmailSendingException : Exception
    {
        public EmailSendingException(string message) : base(message) { }
    }
}
