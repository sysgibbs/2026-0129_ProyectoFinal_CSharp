using System.ComponentModel.DataAnnotations;

namespace CineMVC.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        
        [Required, StringLength(150)]
        public string Titulo { get; set; } = string.Empty;

        [StringLength(500)]
        public string ? Sinposis { get; set; }

        [StringLength(20)]
        public string? Clasificacion { get; set;  }

        [StringLength(50)]
        public string? Genero { get; set; }

        public bool Activa { get; set; } = true;

        [Range(1,500)]
        public int DuracionMin {  get; set; }

        public ICollection<Funcion> Funciones { get; set; } = new List<Funcion>();
    
    }
}
