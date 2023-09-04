﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Shared.Responses
{
    public class PageResponse<TItem>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public int Count { get; set; }
        public IEnumerable<TItem> Data { get; set; } = new List<TItem>();
    }
}
