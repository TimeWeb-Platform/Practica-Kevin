using System.ComponentModel.DataAnnotations;

namespace TimeWebAttendanceEvents.Model
{
    public class Evento
    {
        public Evento(int EventoId, int UsuarioId, DateTime FechaAlta,
            double? Latitud, double? Longitud, int Origen)
        {
            this.EventoId = EventoId;
            this.UsuarioId = UsuarioId;
            this.FechaAlta = FechaAlta;
            this.Latitud = Latitud;
            this.Longitud = Longitud;
            this.Origen = Origen;

        }
        [Required]
        [Key]
        public int EventoId { get; set; }
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
