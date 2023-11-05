using System.ComponentModel.DataAnnotations;

namespace DevOps_cp3.Models
{
    public class Usuario : BaseEntity
    {
        [Required]
        public String Nome { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Senha { get; set; }

        public virtual ICollection<Evento>? Eventos { get; set; } = new List<Evento>();
        public virtual ICollection<Lembrete>? Lembretes { get; set; } = new List<Lembrete>();
    }
}
