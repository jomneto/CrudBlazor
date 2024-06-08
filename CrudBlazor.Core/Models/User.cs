namespace CrudBlazor.Core.Models
{
    public class User
    {
        public virtual ulong userId { get; set; }
        public virtual string userEmail { get; set; } = string.Empty;
        public virtual string userPasswordHash { get; set; } = string.Empty;
        public virtual bool userFlagDeleted { get; set; } = false;
    }
}
