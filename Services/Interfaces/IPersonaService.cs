using CineMVC.Models;

namespace CineMVC.Services.Interfaces
{
    public interface IPersonaService
    {
        Task<List<Persona>> GetAllAsync();
        Task<Persona?> GetByIdAsync(int id);
        Task CreateAsync(Persona persona);
        Task UpdateAsync(Persona persona);
        Task DeleteAsync(int id);
    }
}