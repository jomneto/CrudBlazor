using System.Text.Json.Serialization;

namespace CrudBlazor.Core.CRUD
{
    public class PaginateResponse<TObject>
    {
        public int PageSize { get; set; } = 0;
        public int PageNumber { get; set; } = 0;
        public int TotalRecords { get; set; } = 0;
        public int TotalPages { get; set; } = 0;
        public List<TObject> Data { get; set; } = [];

        [JsonIgnore]
        public int Skip => (PageNumber - 1) * PageSize;

    }
}
