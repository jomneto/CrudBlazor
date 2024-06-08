using CrudBlazor.Core.CRUD;
using CrudBlazor.Core.Interfaces;
using CrudBlazor.Core.Models;

namespace CrudBlazor.Api.ORM.DAO
{
    public class UserDAO : ICrud<User, string>
    {
        private NHibernate.ISession session { get; set; } = null!;
        public UserDAO(NHibernate.ISession session) => this.session = session;

        public User? FindByID(ulong id)
        {
            return session.Get<User>(id);
        }
        public PaginateResponse<User> FindAll(PaginateRequest<string> filter)
        {
            try
            {
                var query = session.Query<User>()
                    .Where(x => x.userEmail.Contains(filter.Filter ?? ""))
                    .OrderBy(o => o.userEmail);

                return query.ToPaginateResponse<User, string>(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User? SaveOrUpdate(User obj)
        {
            var t = session.BeginTransaction();
            try
            {
                var result = session.Get<User>(obj.userId);
                if (result != null)
                {
                    result.userEmail = obj.userEmail;
                    result.userFlagDeleted = obj.userFlagDeleted;
                    result.userPasswordHash = obj.userPasswordHash;
                    session.Update(result);
                    t.Commit();
                }
                else
                {
                    session.Save(obj);
                    t.Commit();
                    result = obj;
                }
                return result;
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
                var obj = session.Get<User>(id);
                if (obj != null)
                {
                    session.Delete(obj);
                    t.Commit();
                }
                return true;
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
