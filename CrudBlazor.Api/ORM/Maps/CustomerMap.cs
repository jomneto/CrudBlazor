using CrudBlazor.Core.Models;
using FluentNHibernate.Mapping;

namespace CrudBlazor.Api.ORM.Maps
{
    public class CustomerMap: ClassMap<Customer>
    {
        public CustomerMap() 
        {
            Table("customer");

            Id(x => x.customerId);

            Map(x => x.customerName);
            Map(x => x.customerBirthDate);
            Map(x => x.customerFlagDeleted);
        }
    }
}
