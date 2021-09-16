using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class PaginationRequest
    {
        private int _pageSize;
        private int _pageIndex;

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (value <= 0)
                    _pageSize = 10;
                else
                    _pageSize = value;
            }
        }

        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                if (value <= 0)
                    _pageIndex = 1;
                else
                    _pageIndex = value;
            }
        }

        public string Sort { get; set; }
        public string Direction { get; set; }
    }
}
