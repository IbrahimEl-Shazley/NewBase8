using System.Collections.Generic;

namespace NewBase.Core.Models.DTO
{
    public class PageDTO<T>
    {
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public List<T> Data { get; set; }
    }

    public class PageDTO : PageDTO<object>
    {

    }
}
