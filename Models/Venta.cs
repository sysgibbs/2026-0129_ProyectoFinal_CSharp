using CineMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CineMVC.Models
{
    public class Venta
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; } = null!;

        public DateTime FechaVenta { get; set; } = DateTime.Now;

        [Range(typeof(decimal), "0.01", "999999")]
        public decimal MontoTotal { get; set; }

        [Required, StringLength(30)]
        public string MetodoVenta { get; set; } = string.Empty;

        public EstadoVenta Estado { get; set; } = EstadoVenta.Pagado;

        [Required, StringLength(50)]
        public string CodigoConfirmacion { get; set; } = string.Empty;

        public ICollection<Entrada> Entradas { get; set; } = new List<Entrada>();
    }
}