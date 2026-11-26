using CineMVC.Data;

namespace CineMVC.Models
{
	public class Empleado
	{
		public int Id { get; set; }

		public int PersonaId { get; set; }
		public Persona Persona { get; set; } = null!;

		public string? ApplicationUserId { get; set; }
		public ApplicationUser? ApplicationUser { get; set; }

		public string Cargo { get; set; } = string.Empty;

		public ICollection<Venta> VentasRegistradas { get; set; } = new List<Venta>();
	}
}