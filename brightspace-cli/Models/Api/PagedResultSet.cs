using System.Collections.Generic;

namespace BrightspaceCli.Models.Api
{
    public class PagingInfo
    {
        public string Bookmark { get; set; }

        public bool HasMoreItems { get; set; }
    }

    public class PagedResultSet<T>
    {
        public PagingInfo PagingInfo { get; set; }

        public List<T> Items { get; set; }
    }
}
