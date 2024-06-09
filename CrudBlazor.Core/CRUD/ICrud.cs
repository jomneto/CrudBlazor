using CrudBlazor.Core.CRUD;

namespace CrudBlazor.Core.Interfaces
{
    public interface ICrud<TObject, TFilter>
    {
        TObject? FindByID(ulong id);
        PaginateResponse<TObject> FindAll(PaginateRequest<TFilter> paginateRequest);
        TObject? SaveOrUpdate(TObject obj);
        bool Delete(ulong id);

    }
}
