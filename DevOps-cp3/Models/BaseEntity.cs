using System.ComponentModel.DataAnnotations;

namespace DevOps_cp3.Models
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
