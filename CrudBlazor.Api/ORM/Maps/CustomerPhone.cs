using CrudBlazor.Api.ORM.PO;
using FluentNHibernate.Mapping;

namespace CrudBlazor.Api.ORM.Maps
{
    public class CustomerPhoneMap: ClassMap<CustomerPhonePO>
    {
        public CustomerPhoneMap()
        {
            Table("customer_phone");

            Id(x => x.customerId).GeneratedBy.Identity();

            Map(x => x.customerPhoneNumber);
            Map(x => x.customerPhoneFlagDeleted);
        }

    }
}
