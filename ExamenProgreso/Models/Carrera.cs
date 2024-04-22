using System.ComponentModel.DataAnnotations;

namespace ExamenProgreso1.Models
{
    public class Carrera
    {
        public string Id { get; set; }
        [Required]
        public string? NombreCarrera { get; set; }
        [Required]
        public string? Campus { get; set; }
        [Required]
        public int? NumeroSemestres { get; set; }

    }
}
