using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakEase.BLL.Filters
{
    public class PaginationEmployeeFilter : PaginationFilter
    {
        public string? Status { get; set; }
    }
}
