using System.ComponentModel.DataAnnotations;

namespace CineMVC.Models
{
    public class Entrada
    {
        public int Id { get; set; }

        public int PagoId { get; set; }
        public Pago Pago { get; set; } = null!;

        public int FuncionId { get; set; }
        public Funcion Funcion { get; set; } = null!;

        
        [Required, StringLength(10)]
        public string Asiento { get; set; } = string.Empty;


        [Range(typeof(decimal), "0.01", "999999")]
        public decimal Precio { get; set; }
    }
}