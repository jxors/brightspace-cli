using System.Collections.Generic;

namespace BrightspaceCli.Models.Api
{
    public class ObjectListPage<T>
    {
        public string Next { get; set; }

        public List<T> Objects { get; set; }
    }
}
