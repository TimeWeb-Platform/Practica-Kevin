
using System.ComponentModel.DataAnnotations;

namespace TimeWebAttendanceUsers.DTO
{
    public class UsuarioDTO
    {
        [Required]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string ApP { get; set; }
        public string ApM { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public int RazonSocialId { get; set; }
    }
}
