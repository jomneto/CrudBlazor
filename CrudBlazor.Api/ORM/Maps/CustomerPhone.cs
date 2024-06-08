﻿using CrudBlazor.Core.Models;
using FluentNHibernate.Mapping;

namespace CrudBlazor.Api.ORM.Maps
{
    public class CustomerPhoneMap: ClassMap<CustomerPhone>
    {
        public CustomerPhoneMap()
        {
            Table("customer_phone");

            Id(x => x.customerId);

            Map(x => x.customerPhoneNumber);
            Map(x => x.customerPhoneFlagDeleted);
        }

    }
}
