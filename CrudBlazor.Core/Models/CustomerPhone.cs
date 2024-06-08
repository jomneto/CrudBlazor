namespace CrudBlazor.Core.Models
{
    public class CustomerPhone
    {
        public virtual ulong customerPhoneId { get; set; }
        public virtual ulong customerId { get; set; }
        public virtual string customerPhoneNumber { get; set; } = string.Empty;
        public virtual bool customerPhoneFlagDeleted { get; set; } = false;
    }
}
