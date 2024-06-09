using System.ComponentModel.DataAnnotations;

namespace CrudBlazor.Core.Models
{
    public class Customer
    {
        public virtual ulong Id { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="O nome não pode ficar em branco")]
        public virtual string Name { get; set; } = string.Empty;

        public string? BirthDate { get; set; }

        public virtual bool IsDeleted { get; set; } = false;
    }
}
