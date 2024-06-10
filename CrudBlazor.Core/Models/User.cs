using System.ComponentModel.DataAnnotations;

namespace CrudBlazor.Core.Models
{
    public class User
    {
        public ulong Id { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Informe um e-mail"),
         EmailAddress(ErrorMessage ="Digite um e-mail válido")]

        public string Email { get; set; } = string.Empty;
        [Required(AllowEmptyStrings =false, ErrorMessage ="O nome é um campo obrigatório")]
        public string Name { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = [];
        public bool IsDeleted { get; set; } = false;
    }
}
