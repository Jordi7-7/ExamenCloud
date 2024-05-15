namespace ExamenCloud.Entidades
{
    public class Distribuidor
    {
        public int Id { get; set; } //Clave Primaria
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public int Stock { get; set; }
        public List<VideoJuego>? Videojuegos { get; set; }

    }
}