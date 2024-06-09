using System.ComponentModel.DataAnnotations;

namespace CrudBlazor.Core.Models
{
    public class CustomerPhone
    {
        public virtual ulong Id { get; set; }

        public virtual ulong CustomerId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="O telefone é obrigatório"), 
         MinLength(length:10, ErrorMessage ="O telefoe deve ter no mínimo 10 digitos"),
         MaxLength(length:11, ErrorMessage = "O telefone deve ter no máximo 11 digitos")]
        public virtual string Number { get; set; } = string.Empty;

        public virtual bool IsDeleted { get; set; } = false;
    }
}
