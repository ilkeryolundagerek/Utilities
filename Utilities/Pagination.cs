using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Pagination<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public IEnumerable<T> Items { get; set; }

        public Pagination(IEnumerable<T> all_items, int pagesize, int currentPage = 1, int pageLimit = 0)
        {
            CurrentPage = currentPage;
            PageSize = pagesize;
            TotalPages = all_items.Count() % pagesize > 0 ? all_items.Count() / pagesize + 1 : all_items.Count() / pagesize;
            if (pageLimit > 0)
            {
                StartPage = currentPage - pageLimit <= 1 ? 1 : currentPage - pageLimit;
                EndPage = currentPage + pageLimit >= TotalPages ? TotalPages : currentPage + pageLimit;
            }
            else
            {
                StartPage = 1;
                EndPage = TotalPages;
            }
            Items = all_items.Skip((currentPage - 1) * pagesize).Take(pagesize).ToList();
        }
    }
}
