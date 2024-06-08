namespace CrudBlazor.Core.Models
{
    public class Customer
    {
        public virtual ulong customerId { get; set; }
        public virtual string customerName { get; set; } = string.Empty;
        public virtual DateOnly? customerBirthDate { get; set; }
        public virtual bool customerFlagDeleted { get; set; } = false;
    }
}
