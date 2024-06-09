using CrudBlazor.Core.Extensions;
using CrudBlazor.Core.Models;

namespace CrudBlazor.Api.ORM.PO
{
    public class CustomerPO
    {
        public virtual ulong customerId { get; set; }
        public virtual string customerName { get; set; } = string.Empty;
        public virtual DateTime? customerBirthDate { get; set; }
        public virtual bool customerFlagDeleted { get; set; } = false;

        public static explicit operator CustomerPO?(Customer? obj)
        {
            if (obj == null) return null;
            else
                return new CustomerPO()
                {
                    customerId = obj.Id,
                    customerName = obj.Name,
                    customerBirthDate = obj.BirthDate.StringToDate(),
                    customerFlagDeleted = obj.IsDeleted
                };
        }

        public static explicit operator Customer?(CustomerPO? po)
        {
            if (po == null) return null;
            else
                return new Customer()
                {
                    Id = po.customerId,
                    Name = po.customerName,
                    BirthDate = po.customerBirthDate.DateToString(),
                    IsDeleted = po.customerFlagDeleted
                };
        }

    }

}
