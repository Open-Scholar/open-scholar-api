﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Shared.CustomExceptions.UserExceptions
{
    public class UserDataException : Exception
    {
        public UserDataException(string message) : base(message) { }

    }
}
