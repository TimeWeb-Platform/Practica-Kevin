using System.ComponentModel.DataAnnotations;

namespace TimeWebAttendanceEvaluation.Model
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        public int UsuarioId { get; set; }
        public DateOnly Fecha { get; set; }
        public bool Asistencia { get; set; }
    }
}
