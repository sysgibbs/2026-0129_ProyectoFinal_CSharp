using System;
using System.ComponentModel.DataAnnotations;

namespace CineMVC.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }

        public Persona Persona { get; set; } = null!;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    }
}
