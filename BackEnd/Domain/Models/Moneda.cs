using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
    public class Moneda
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string CodigoMoneda { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string DescripcionMoneda { get; set; }
    }
}
