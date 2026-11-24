namespace CineMVC.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        public int PersonaId { get; set;  }
        public Persona Persna { get; set; } = null!;

        public string Cargo { get; set; } = string.Empty;

        public ICollection<Pago> PagosRegistrados { get; set; } = new List<Pago>();
     }
}
