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
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Entrada> Entradas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Precisión decimal
            builder.Entity<Venta>()
                .Property(v => v.MontoTotal)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Venta>()
                .Property(v => v.Estado)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Entity<Entrada>()
                .Property(e => e.Precio)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Funcion>()
                .Property(f => f.PrecioBase)
                .HasColumnType("decimal(18,2)");

            // Relaciones uno a muchos
            builder.Entity<Entrada>()
                .HasOne(e => e.Venta)
                .WithMany(v => v.Entradas)
                .HasForeignKey(e => e.VentaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Entrada>()
                .HasOne(e => e.Funcion)
                .WithMany(f => f.Entradas)
                .HasForeignKey(e => e.FuncionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Venta>()
                .HasOne(v => v.Empleado)
                .WithMany(e => e.VentasRegistradas)
                .HasForeignKey(v => v.EmpleadoId)
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

            // Relaciones uno a uno
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

            // Relación Empleado -> ApplicationUser
            builder.Entity<Empleado>()
                .HasOne(e => e.ApplicationUser)
                .WithOne()
                .HasForeignKey<Empleado>(e => e.ApplicationUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Índices únicos
            builder.Entity<Venta>()
                .HasIndex(v => v.CodigoConfirmacion)
                .IsUnique();

            builder.Entity<Entrada>()
                .HasIndex(e => new { e.FuncionId, e.Asiento })
                .IsUnique();
        }
    }
}