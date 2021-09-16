using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class FilterRequest : PaginationRequest
    {
        public string Term { get; set; }
    }
}
