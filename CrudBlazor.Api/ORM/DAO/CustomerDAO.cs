using CrudBlazor.Core.CRUD;
using CrudBlazor.Core.Interfaces;
using CrudBlazor.Core.Models;

namespace CrudBlazor.Api.ORM.DAO
{
    public class CustomerDAO : ICrud<Customer, string>
    {
        NHibernate.ISession session;
        public CustomerDAO(NHibernate.ISession session) => this.session = session;

        public Customer? FindByID(ulong id)
        {
            return session.Get<Customer>(id);
        }

        public PaginateResponse<Customer> FindAll(PaginateRequest<string> paginateRequest)
        {
            var query = session.Query<Customer>()
                .Where(x => !x.customerFlagDeleted);

            if (!string.IsNullOrEmpty(paginateRequest.Filter))
                query = query.Where(x => x.customerName.Contains(paginateRequest.Filter.ToLike()));

            query = query.OrderBy(x => x.customerName);

            return query.ToPaginateResponse<Customer, string>(paginateRequest);
        }

        public Customer? SaveOrUpdate(Customer obj)
        {
            var t = session.BeginTransaction();

            try
            {
                var result = session.Get<Customer>(obj.customerId);
                if (result != null)
                {
                    result.customerName = obj.customerName;
                    result.customerBirthDate = obj.customerBirthDate;
                    result.customerFlagDeleted = obj.customerFlagDeleted;
                    session.Update(result);
                    t.Commit();
                    return result;
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
                var obj = session.Get<Customer>(id);
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
