﻿using CrudBlazor.Core.CRUD;
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
        public PaginateResponse<User> FindAll(PaginateRequest<string> paginateRequest)
        {
            var query = session.Query<User>()
                .Where(x => !x.userFlagDeleted);

            if (!string.IsNullOrEmpty(paginateRequest.Filter))
            {
                query = query.Where(x => x.userEmail.Contains(paginateRequest.Filter.ToLike()) || x.userName.Contains(paginateRequest.Filter.ToLike()));
            }

            query = query.OrderBy(x => x.userName);

            return query.ToPaginateResponse<User, string>(paginateRequest);
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
                    obj.userFlagDeleted = true;
                    session.Update(obj);
                    t.Commit();
                    return true;
                } else
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
