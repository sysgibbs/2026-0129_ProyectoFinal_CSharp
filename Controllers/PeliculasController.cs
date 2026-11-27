using CineMVC.Models;
using CineMVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PeliculasController : Controller
    {
        private readonly IPeliculaService _peliculaService;

        public PeliculasController(IPeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }

        public async Task<IActionResult> Index()
        {
            var peliculas = await _peliculaService.GetAllAsync();
            return View(peliculas);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var pelicula = await _peliculaService.GetByIdAsync(id.Value);
            if (pelicula == null) return NotFound();
            return View(pelicula);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pelicula pelicula)
        {
            if (!ModelState.IsValid) return View(pelicula);
            await _peliculaService.CreateAsync(pelicula);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var pelicula = await _peliculaService.GetByIdAsync(id.Value);
            if (pelicula == null) return NotFound();
            return View(pelicula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pelicula pelicula)
        {
            if (id != pelicula.Id) return NotFound();
            if (!ModelState.IsValid) return View(pelicula);
            await _peliculaService.UpdateAsync(pelicula);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var pelicula = await _peliculaService.GetByIdAsync(id.Value);
            if (pelicula == null) return NotFound();
            return View(pelicula);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _peliculaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}