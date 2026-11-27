using CineMVC.Models;
using CineMVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PersonasController : Controller
    {
        private readonly IPersonaService _personaService;

        public PersonasController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        public async Task<IActionResult> Index()
        {
            var personas = await _personaService.GetAllAsync();
            return View(personas);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var persona = await _personaService.GetByIdAsync(id.Value);
            if (persona == null) return NotFound();
            return View(persona);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Persona persona)
        {
            if (!ModelState.IsValid) return View(persona);
            await _personaService.CreateAsync(persona);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var persona = await _personaService.GetByIdAsync(id.Value);
            if (persona == null) return NotFound();
            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Persona persona)
        {
            if (id != persona.Id) return NotFound();
            if (!ModelState.IsValid) return View(persona);
            await _personaService.UpdateAsync(persona);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var persona = await _personaService.GetByIdAsync(id.Value);
            if (persona == null) return NotFound();
            return View(persona);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _personaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}