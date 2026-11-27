using CineMVC.Models;

namespace CineMVC.Services.Interfaces
{
    public interface IPeliculaService
    {
        Task<List<Pelicula>> GetAllAsync();
        Task<Pelicula?> GetByIdAsync(int id);
        Task CreateAsync(Pelicula pelicula);
        Task UpdateAsync(Pelicula pelicula);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
