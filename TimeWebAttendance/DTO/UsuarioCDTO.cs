namespace TimeWebAttendanceUsers.DTO
{
    public class UsuarioCDTO
    {
        public string Nombre { get; set; }
        public string ApP { get; set; }
        public string ApM { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public int RazonSocialId { get; set; }
    }
}
