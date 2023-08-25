using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Shared.CustomExceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException() : base("An error occurred, contact the admin!")
        {

        }
    }
}
