using CrudBlazor.Core.CRUD;

namespace CrudBlazor.Core.Interfaces
{
    public interface ICrud<T, TPO, TFilter>
    {
        T? FindByID(ulong id);
        PaginateResponse<T, TPO> FindAll(PaginateRequest<TFilter> paginateRequest);
        T? SaveOrUpdate(T obj);
        bool Delete(ulong id);

    }
}
