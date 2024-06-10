using System.ComponentModel.DataAnnotations;

namespace CrudBlazor.Core.Models
{
    public class CustomerPhone
    {
        public ulong Id { get; set; }

        public ulong CustomerId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="O telefone é obrigatório"), 
         MinLength(length:10, ErrorMessage ="O telefoe deve ter no mínimo 10 digitos"),
         MaxLength(length:11, ErrorMessage = "O telefone deve ter no máximo 11 digitos")]
        public string Number { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;
    }
}
