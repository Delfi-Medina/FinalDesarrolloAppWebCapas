using Gastos.Modelos;
using Gastos.Negocios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Gastos.Presentacion.Controllers
{
    public class GastoController : Controller
    {
        private readonly GastoServicio _gastoServicio;

        public GastoController(GastoServicio gastoServicio)
        {
            _gastoServicio = gastoServicio;
        }

        public async Task<IActionResult> Index()
        {
            var gastos = await _gastoServicio.ObtenerTodosLosGastos();
            return View("Index", gastos);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _gastoServicio.AgregarGasto(gasto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al agregar el gasto: " + ex.Message);
                }
            }
            return View(gasto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gasto = await _gastoServicio.ObtenerGastoPorId(id.Value);
            if (gasto == null)
            {
                return NotFound();
            }

            return View("Edit", gasto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Gasto gastoEditado)
        {
            if (id != gastoEditado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _gastoServicio.ActualizarGasto(gastoEditado);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al actualizar el gasto: " + ex.Message);
                }
            }

            return View(gastoEditado);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gasto = await _gastoServicio.ObtenerGastoPorId(id.Value);
            if (gasto == null)
            {
                return NotFound();
            }

            return View("Details", gasto);
        }

        
        
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _gastoServicio.EliminarGasto(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
    


