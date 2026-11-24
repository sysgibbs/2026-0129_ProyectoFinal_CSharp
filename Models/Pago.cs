using CineMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CineMVC.Models
{
    public class Pago
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; } = null!;

        public DateTime FechaPago { get; set; } = DateTime.Now;


        [Range(typeof(decimal), "0.01", "999999")]
        public decimal MontoTotal { get; set; }

        public string MetodoPago { get; set; } = string.Empty;

        public EstadoPago Estado { get; set; } = EstadoPago.Pagado;

        public ICollection<Entrada> Entradas { get; set; } = new List<Entrada>();
    }
}