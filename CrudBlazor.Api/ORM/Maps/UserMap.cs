using CrudBlazor.Api.ORM.PO;
using FluentNHibernate.Mapping;
using NHibernate.Json;

namespace CrudBlazor.Api.ORM.Maps
{
    public class UserMap : ClassMap<UserPO>
    {
        public UserMap()
        {
            Table("user");

            Id(x => x.userId).GeneratedBy.Identity();

            Map(x => x.userEmail);
            Map(x => x.userName);
            Map(x => x.userPasswordHash);
            Map(x => x.userRoles).CustomType<JsonColumnType<List<string>>>().Nullable();
            Map(x => x.userFlagDeleted);
        }

    }
}
