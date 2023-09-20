﻿using OpenScholarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IBookRatingRepository : IBaseRepository<BookRating>
    {
        //Task<BookRating> GetByUserIdAndBookIdAsync(string userId, int bookId);
    }
}