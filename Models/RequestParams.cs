﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models
{
    public class RequestParams
    {
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;

        public int PageSize { get { return pageSize; } set { pageSize = (value > maxPageSize) ? maxPageSize : value; } }
    }
}
