using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CineMVC.Models;
using CineMVC.Models.Enums;

namespace CineMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Entrada> Entradas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            builder.Entity<Pago>()
                .Property(p => p.MontoTotal)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Pago>()
                .Property(p => p.Estado)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Entity<Entrada>()
                .Property(e => e.Precio)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Funcion>()
                .Property(f => f.PrecioBase)
                .HasColumnType("decimal(18,2)");

            
            builder.Entity<Entrada>()
                .HasOne(e => e.Pago)
                .WithMany(p => p.Entradas)
                .HasForeignKey(e => e.PagoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Entrada>()
                .HasOne(e => e.Funcion)
                .WithMany(f => f.Entradas)
                .HasForeignKey(e => e.FuncionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Pago>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Pagos)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Pago>()
                .HasOne(p => p.Empleado)
                .WithMany(e => e.PagosRegistrados)
                .HasForeignKey(p => p.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Funcion>()
                .HasOne(f => f.Pelicula)
                .WithMany(p => p.Funciones)
                .HasForeignKey(f => f.PeliculaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Funcion>()
                .HasOne(f => f.Sala)
                .WithMany(s => s.Funciones)
                .HasForeignKey(f => f.SalaId)
                .OnDelete(DeleteBehavior.Restrict);

            
            builder.Entity<Cliente>()
                .HasOne(c => c.Persona)
                .WithOne()
                .HasForeignKey<Cliente>(c => c.PersonaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Empleado>()
                .HasOne(e => e.Persona)
                .WithOne()
                .HasForeignKey<Empleado>(e => e.PersonaId)
                .OnDelete(DeleteBehavior.Restrict);

            
            builder.Entity<Entrada>()
                .HasIndex(e => new { e.FuncionId, e.Asiento })
                .IsUnique();
        }
    }
}