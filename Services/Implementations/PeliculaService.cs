using CineMVC.Data;
using CineMVC.Models;
using CineMVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CineMVC.Services.Implementations
{
    public class PeliculaService : IPeliculaService
    {
        private readonly ApplicationDbContext _context;

        public PeliculaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pelicula>> GetAllAsync()
        {
            return await _context.Peliculas
                .AsNoTracking()
                .OrderBy(p => p.Titulo)
                .ToListAsync();
        }

        public async Task<Pelicula?> GetByIdAsync(int id)
        {
            return await _context.Peliculas
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateAsync(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pelicula pelicula)
        {
            _context.Peliculas.Update(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);
            if (pelicula != null)
            {
                _context.Peliculas.Remove(pelicula);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Peliculas.AnyAsync(p => p.Id == id);
        }
    }
}
