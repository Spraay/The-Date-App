using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pagination
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }


            public static async Task<PaginatedList<T>> CreateAsync<T>(IOrderedQueryable<T> qry, int pageIndex, int pageSize) where T : class
            {
                var totalRecordCount = await qry.CountAsync();
                return new PaginatedList<T>(await qry.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(), totalRecordCount, pageIndex, pageSize);
            }

   

            public static PaginatedList<T> Create<T>(IEnumerable<T> qry, int pageIndex, int pageSize) where T : class
            {
                var totalRecordCount = qry.Count();
                return new PaginatedList<T>(qry.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(), totalRecordCount, pageIndex, pageSize);
        }
        
    }
}
