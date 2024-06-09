using System.Text.Json.Serialization;

namespace CrudBlazor.Core.CRUD
{
    public class PaginateResponse<T, TPO>
    {
        public int PageSize { get; set; } = 0;
        public int PageNumber { get; set; } = 0;
        public int TotalRecords { get; set; } = 0;
        public int TotalPages { get; set; } = 0;
        public List<T> Data { get; set; } = [];

        [JsonIgnore]
        public int Skip => (PageNumber - 1) * PageSize;

        public void FeedData(IQueryable<TPO> query, Action<TPO> feedAction)
        {
            // Alimenta os dados
            query
                .Skip(Skip)
                .Take(PageSize)
                .ToList()
                .ForEach(feedAction);
        }

    }
}
