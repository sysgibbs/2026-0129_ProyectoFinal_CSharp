using System.ComponentModel.DataAnnotations;

namespace CineMVC.Models
{
    public class Sala
    {

        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(30)]
        public string? Tipo { get; set; }

        [Range(1,1000)]
        public int Capacidad { get; set; }


        public ICollection<Funcion> Funciones { get; set; } = new List<Funcion>();

    }
}
