using System.ComponentModel.DataAnnotations;
namespace TimeWebAttendanceEvents.DTO
{
    public class EventoDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaAlta { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public int Origen { get; set; }
    }
}
