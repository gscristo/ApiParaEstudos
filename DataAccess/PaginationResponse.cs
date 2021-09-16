namespace DataAccess
{
    using System.Collections.Generic;

    public class PaginationResponse<T>
    {
        public IEnumerable<T> DataList { get; set; }
        public int TotalRecords { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
