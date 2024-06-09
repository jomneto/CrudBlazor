using CrudBlazor.Core.Models;

namespace CrudBlazor.Api.ORM.PO
{
    public class UserPO
    {
        public virtual ulong userId { get; set; }
        public virtual string userEmail { get; set; } = string.Empty;
        public virtual string userName { get; set; } = string.Empty;
        public virtual string userPasswordHash { get; set; } = string.Empty;
        public virtual bool userFlagDeleted { get; set; } = false;

        public static explicit operator UserPO?(User? obj)
        {
            if (obj == null) return null;
            else
                return new UserPO()
                {
                    userId = obj.Id,
                    userEmail = obj.Email,
                    userName = obj.Name,
                    userPasswordHash = obj.PasswordHash,
                    userFlagDeleted = obj.IsDeleted
                };
        }

        public static explicit operator User?(UserPO? po)
        {
            if (po == null) return null;
            else
                return new User()
                {
                    Id = po.userId,
                    Email = po.userEmail,
                    Name = po.userName,
                    PasswordHash = po.userPasswordHash,
                    IsDeleted = po.userFlagDeleted
                };
        }

    }
}
