using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
    public class Sucursal
    {
        [Key]
        [Column(TypeName = "int")]
        public int Codigo { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Descripcion { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Direccion { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Identificacion { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaCreacion { get; set; }
        public Moneda Moneda { get; set; }
        [NotMapped]
        public int IdMoneda { get; set; }
    }
}
