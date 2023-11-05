using System.ComponentModel.DataAnnotations;

namespace DevOps_cp3.Models
{
    public class Lembrete : BaseEntity
    {

        [Required]
        public String Texto { get; set; } = "Exemplo Lembrete";

        [Required]
        public DateTime DataHoraLembrete { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
