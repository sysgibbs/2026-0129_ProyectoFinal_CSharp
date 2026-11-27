using CineMVC.Data;
using CineMVC.Models;
using CineMVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CineMVC.Services.Implementations
{
    public class SalaService : ISalaService
    {
        private readonly ApplicationDbContext _context;

        public SalaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sala>> GetAllAsync()
        {
            return await _context.Salas.AsNoTracking().OrderBy(s => s.Nombre).ToListAsync();
        }

        public async Task<Sala?> GetByIdAsync(int id)
        {
            return await _context.Salas.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task CreateAsync(Sala sala)
        {
            _context.Salas.Add(sala);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sala sala)
        {
            _context.Salas.Update(sala);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala != null)
            {
                _context.Salas.Remove(sala);
                await _context.SaveChangesAsync();
            }
        }
    }
}