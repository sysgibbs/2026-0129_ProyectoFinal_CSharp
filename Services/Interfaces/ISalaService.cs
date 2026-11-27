using CineMVC.Models;

namespace CineMVC.Services.Interfaces
{
    public interface ISalaService
    {
        Task<List<Sala>> GetAllAsync();
        Task<Sala?> GetByIdAsync(int id);
        Task CreateAsync(Sala sala);
        Task UpdateAsync(Sala sala);
        Task DeleteAsync(int id);
    }
}