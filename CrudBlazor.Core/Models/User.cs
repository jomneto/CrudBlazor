using System.ComponentModel.DataAnnotations;

namespace CrudBlazor.Core.Models
{
    public class User
    {
        public virtual ulong Id { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Informe um e-mail"),
         EmailAddress(ErrorMessage ="Digite um e-mail válido")]

        public virtual string Email { get; set; } = string.Empty;
        [Required(AllowEmptyStrings =false, ErrorMessage ="O nome é um campo obrigatório")]
        public virtual string Name { get; set; } = string.Empty;

        public virtual string PasswordHash { get; set; } = string.Empty;

        public virtual bool IsDeleted { get; set; } = false;
    }
}
