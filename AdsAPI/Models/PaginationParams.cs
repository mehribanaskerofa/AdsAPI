using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdsAPI.Models
{
    public class PaginationParams
    {
        private const int MAX_PAGE_SIZE = 100;
        private int _pageSize = 10;
       

        public int PageIndex { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
        }

        public bool Sort { get; set; } = true;
        public string FieldName { get ; set ; }
    }
}
