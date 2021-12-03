using System.Collections.Generic;

namespace TriMania.Infra.Database.Repository.Base
{
    public class QueryResult<T>
    {
        public QueryResult(IEnumerable<T> items, PaginationInfo paginationInfo)
        {
            Items = items;
            PaginationInfo = paginationInfo;
        }

        public IEnumerable<T> Items { get; }
        public PaginationInfo PaginationInfo { get; }
    }
}