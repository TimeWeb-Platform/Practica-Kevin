using System.ComponentModel.DataAnnotations;

namespace TimeWebAttendanceUsers.Entities
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
        public int RazonSocialId { get; set; }
    }
}
