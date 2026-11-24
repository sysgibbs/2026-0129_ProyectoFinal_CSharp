using System.ComponentModel.DataAnnotations;


namespace CineMVC.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [Required, StringLength(80)] 
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(80)]
        public string Apellido { get; set; } = string.Empty;

        [StringLength(20)]
        public string ? Cedula { get; set; }

        [EmailAddress, StringLength(120)]
        public string? Email { get; set; }

        [StringLength (20)]
        public string? Telefono { get; set; }

    }
}
