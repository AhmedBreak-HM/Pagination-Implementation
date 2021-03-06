using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination_Implemention.Paging
{
    public class PaginationUserParams
    {
        private const int MaxSize = 50;
        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value>MaxSize)? MaxSize:value; }
        }

    }
}
