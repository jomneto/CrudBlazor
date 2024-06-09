using CrudBlazor.Core.Models;

namespace CrudBlazor.Api.ORM.PO
{
    public class CustomerPhonePO
    {
        public virtual ulong customerPhoneId { get; set; }
        public virtual ulong customerId { get; set; }
        public virtual string customerPhoneNumber { get; set; } = string.Empty;
        public virtual bool customerPhoneFlagDeleted { get; set; } = false;

        public static implicit operator CustomerPhonePO?(CustomerPhone? obj)
        {
            if (obj == null) return null;
            else
                return new CustomerPhonePO()
                {
                    customerPhoneId = obj.Id,
                    customerId = obj.CustomerId,
                    customerPhoneNumber = obj.Number,
                    customerPhoneFlagDeleted = obj.IsDeleted
                };
        }

        public static implicit operator CustomerPhone?(CustomerPhonePO? po)
        {
            if (po == null) return null;
            else
                return new CustomerPhone()
                {
                    Id = po.customerPhoneId,
                    CustomerId = po.customerId,
                    Number = po.customerPhoneNumber,
                    IsDeleted = po.customerPhoneFlagDeleted
                };
        }
    }
}
