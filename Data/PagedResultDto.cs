]using System;
using System.Collections.Generic;

namespace Data
{
    public class PagedResultDto<T>
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }

        public PagedResultDto(List<T> Data, int TotalCount)
        {
            this.Data = Data;
            this.TotalCount = TotalCount;
        }

    }
}
