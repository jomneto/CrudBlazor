namespace CrudBlazor.Core.CRUD
{
    public class PaginateRequest<TFilter>
    {
        public int PageSize { get; set; } = 25;
        public int PageNumber { get; set; } = 1;
        public TFilter? Filter { get; set; }

        public int Skip => (PageNumber - 1) * PageSize;
    }
}
