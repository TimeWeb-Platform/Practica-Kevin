using System.ComponentModel.DataAnnotations;

namespace TimeWebAttendanceUsers.Entities
{
    public class Usuario
    {
        public Usuario(int Id, string Nombre, string ApP, string ApM, 
            DateTime FechaNacimiento, int RazonSocialId)
        {
            this.Id = Id; this.Nombre = Nombre; this.ApP = ApP;
            this.FechaNacimiento = FechaNacimiento; this.RazonSocialId = RazonSocialId;
        }
        [Required]
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApP { get; set; }
        public string ApM { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [Range(1,3)]
        public int RazonSocialId { get; set; }
    }
}
