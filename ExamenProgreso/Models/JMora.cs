using System.ComponentModel.DataAnnotations;

namespace ExamenProgreso1.Models
{
    public class JMora
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }
        public int NumeroTelefono { get; set; }
        public decimal Sueldo { get; set; }
        public Boolean EsMayorDeEdad { get; set; }

        [Required]
        public DateTime? FechaNacimiento { get; set; }


        public Carrera carrera { get; set; }
    }
}
