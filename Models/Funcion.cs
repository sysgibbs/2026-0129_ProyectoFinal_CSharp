using System.ComponentModel.DataAnnotations;

namespace CineMVC.Models
{
    public class Funcion
    {
        public int Id { get; set; }

        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; } = null!;

        public int SalaId { get; set; }
        public Sala Sala { get; set; } = null!;
        public DateTime FechaHora { get; set; }

        [Range(typeof(decimal), "0.01", "999999")]
        public decimal PrecioBase { get; set; }

        public bool Activa { get; set; } = true;

        public ICollection<Entrada> Entradas { get; set; } = new List<Entrada>();
    }
}
