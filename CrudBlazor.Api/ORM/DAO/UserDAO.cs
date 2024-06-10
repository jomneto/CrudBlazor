using CrudBlazor.Api.ORM.PO;
using CrudBlazor.Core.CRUD;
using CrudBlazor.Core.Interfaces;
using CrudBlazor.Core.Models;
using DefineLIBCore.Library;

namespace CrudBlazor.Api.ORM.DAO
{
    public class UserDAO(NHibernate.ISession _session) : ICrud<User, UserPO, string>
    {
        readonly NHibernate.ISession session = _session;

        public User? FindByID(ulong id)
        {
            return (User?)session.Get<UserPO>(id);
        }
        public PaginateResponse<User, UserPO> FindAll(PaginateRequest<string> paginateRequest)
        {
            var query = session.Query<UserPO>()
                               .Where(x => !x.userFlagDeleted);

            if (!string.IsNullOrEmpty(paginateRequest.Filter))
                query = query.Where(x => x.userEmail.Contains(paginateRequest.Filter.ToLike()) || x.userName.Contains(paginateRequest.Filter.ToLike()));

            query = query.OrderBy(x => x.userName);

            var result = query.ToPaginateResponse<User, UserPO, string>(paginateRequest);
            result.FeedData(query, x => result.Data.Add((User)x!));

            return result;
        }

        public User? SaveOrUpdate(User obj)
        {
            var t = session.BeginTransaction();
            try
            {
                var result = session.Get<UserPO>(obj.Id);
                if (result != null)
                {
                    result.userEmail = obj.Email;
                    result.userName = obj.Name;
                    result.userFlagDeleted = obj.IsDeleted;
                    result.userPasswordHash = obj.PasswordHash;
                    result.userRoles = obj.Roles;
                    session.Update(result);
                    t.Commit();
                    return (User?)result;
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
            finally { t.Dispose(); }

        }

        public bool Delete(ulong id)
        {
            var t = session.BeginTransaction();
            try
            {
                var obj = session.Get<UserPO>(id);
                if (obj != null)
                {
                    obj.userFlagDeleted = true;
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
