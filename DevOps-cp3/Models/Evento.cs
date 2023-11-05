using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DevOps_cp3.Models
{
    public class Evento : BaseEntity
    {
        [Required]
        public string Titulo { get; set; } = "Titulo Exemplo";

        [Required]
        public DateTime DataHora { get; set; }

        [Required]
        public string Descricao { get; set; }

        public virtual Usuario? Usuario { get; set;}
    }
}
