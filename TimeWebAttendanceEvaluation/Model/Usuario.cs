using System.ComponentModel.DataAnnotations;

namespace TimeWebAttendanceEvaluation.Model
{
    public class Usuario
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApP { get; set; }
        public string ApM { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [Range(1, 3)]
        public int RazonSocialId { get; set; }
    }
}
