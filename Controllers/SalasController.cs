using CineMVC.Models;
using CineMVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SalasController : Controller
    {
        private readonly ISalaService _salaService;

        public SalasController(ISalaService salaService)
        {
            _salaService = salaService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _salaService.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var sala = await _salaService.GetByIdAsync(id.Value);
            if (sala == null) return NotFound();
            return View(sala);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sala sala)
        {
            if (!ModelState.IsValid) return View(sala);
            await _salaService.CreateAsync(sala);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var sala = await _salaService.GetByIdAsync(id.Value);
            if (sala == null) return NotFound();
            return View(sala);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sala sala)
        {
            if (id != sala.Id) return NotFound();
            if (!ModelState.IsValid) return View(sala);
            await _salaService.UpdateAsync(sala);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var sala = await _salaService.GetByIdAsync(id.Value);
            if (sala == null) return NotFound();
            return View(sala);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _salaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}