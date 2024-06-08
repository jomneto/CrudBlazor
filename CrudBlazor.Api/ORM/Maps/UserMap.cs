using CrudBlazor.Core.Models;
using FluentNHibernate.Mapping;

namespace CrudBlazor.Api.ORM.Maps
{
    public class UserMap: ClassMap<User>
    {
        public UserMap()
        {
            Table("user");

            Id(x => x.userId);

            Map(x => x.userEmail);
            Map(x => x.userPasswordHash);    
            Map(x => x.userFlagDeleted);
        }

    }
}
