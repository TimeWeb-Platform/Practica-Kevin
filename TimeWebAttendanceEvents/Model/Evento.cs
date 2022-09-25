using System.ComponentModel.DataAnnotations;

namespace TimeWebAttendanceEvents.Model
{
    public class Evento
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public DateTime FechaAlta { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        [Range(1,3)]
        public int Origen { get; set; }
    }
}
