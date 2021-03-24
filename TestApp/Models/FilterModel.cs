using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class FilterModel
    {
        public string Name { get; set; }
        public int? Number { get; set; }
        public int? Category { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public FilterModel()
        {
            PageNumber = 1;
            PageSize = 10;
        }
    }
}
