using CrudBlazor.Api.ORM.PO;
using CrudBlazor.Core.CRUD;
using CrudBlazor.Core.Extensions;
using CrudBlazor.Core.Interfaces;
using CrudBlazor.Core.Models;

namespace CrudBlazor.Api.ORM.DAO
{
    public class CustomerDAO : ICrud<Customer, CustomerPO, string>
    {
        NHibernate.ISession session;
        public CustomerDAO(NHibernate.ISession session) => this.session = session;

        public Customer? FindByID(ulong id)
        {
            return (Customer?)session.Get<CustomerPO>(id);
        }

        public PaginateResponse<Customer, CustomerPO> FindAll(PaginateRequest<string> paginateRequest)
        {

            // Cria a query
            var query = session.Query<CustomerPO>()
                .Where(x => !x.customerFlagDeleted);

            if (!string.IsNullOrEmpty(paginateRequest.Filter))
                query = query.Where(x => x.customerName.Contains(paginateRequest.Filter.ToLike()));

            query = query.OrderBy(x => x.customerName);


            // Cria o PaginateResponse com base na query criada
            var result = query.ToPaginateResponse<Customer, CustomerPO, string>(paginateRequest);
            result.FeedData(query, x => result.Data.Add((Customer)x!));

            return result;
        }

        public Customer? SaveOrUpdate(Customer obj)
        {
            var t = session.BeginTransaction();

            try
            {
                var result = session.Get<CustomerPO>(obj.Id);
                if (result != null)
                {
                    result.customerName = obj.Name;
                    result.customerBirthDate = obj.BirthDate.StringToDate();
                    result.customerFlagDeleted = obj.IsDeleted;
                    session.Update(result);
                    t.Commit();
                    return (Customer?)result;
                }
                else
                {
                    session.Save(obj);
                    t.Commit();
                    return obj;
                }

            }
            catch (Exception)
            {
                t.Rollback();
                throw;
            }
            finally
            {
                t.Dispose();
            }


        }

        public bool Delete(ulong id)
        {
            var t = session.BeginTransaction();

            try
            {
                var obj = session.Get<CustomerPO>(id);
                if (obj != null)
                {
                    obj.customerFlagDeleted = true;
                    session.Update(obj);
                    t.Commit();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                t.Rollback();
                throw;
            }
            finally { t.Dispose(); }

        }
    }
}
