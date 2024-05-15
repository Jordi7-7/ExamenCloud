using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamenCloud.Entidades
{
    public class VideoJuego
    {
        [Key]
        public int Id { get; set; } //PK
        [DisplayName("Nombre del juego")]
        public string Nombre { get; set; }
        public int AñoLanzamiento { get; set; }
        public double Precio { get; set; }
        public int DistribuidorId { get; set; } //FK
        public Distribuidor? Distribuidor { get; set; }
    }
}
