using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapi_c.Models;

namespace webapi_c.Controllers
{
    public class DespesasController : Controller
    {
        private readonly Contexto _context;

        public DespesasController(Contexto context)
        {
            _context = context;
        }

        // GET: Despesas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Despesas.ToListAsync());
        }

        // GET: Despesas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesa = await _context.Despesas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (despesa == null)
            {
                return NotFound();
            }

            return View(despesa);
        }

        // GET: Despesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Despesas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Valor,Data")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(despesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(despesa);
        }

        // GET: Despesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesa = await _context.Despesas.FindAsync(id);
            if (despesa == null)
            {
                return NotFound();
            }
            return View(despesa);
        }

        // POST: Despesas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Valor,Data")] Despesa despesa)
        {
            if (id != despesa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(despesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespesaExists(despesa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(despesa);
        }

        // GET: Despesas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesa = await _context.Despesas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (despesa == null)
            {
                return NotFound();
            }

            return View(despesa);
        }

        // POST: Despesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);
            if (despesa != null)
            {
                _context.Despesas.Remove(despesa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespesaExists(int id)
        {
            return _context.Despesas.Any(e => e.Id == id);
        }

        // Método para gerar relatório de despesas por período
        public async Task<IActionResult> RelatorioDespesasPorPeriodo(DateTime inicio, DateTime fim)
        {
            var despesas = await _context.Despesas
                                .Where(d => d.Data >= inicio && d.Data <= fim)
                                .ToListAsync();

            return View(despesas);
        }

        // Action para gerar relatório de despesas por período
        public async Task<IActionResult> RelatorioDespesasPorPeriodo()
        {
            var inicio = DateTime.Today.AddMonths(-1); // Um mês atrás
            var fim = DateTime.Today; // Hoje
            var despesas = await _context.Despesas
                                .Where(d => d.Data >= inicio && d.Data <= fim)
                                .ToListAsync();

            return View("RelatorioDespesas", despesas);
        }

        // Método para obter despesas por mês
        public async Task<IActionResult> DespesasPorMes()
        {
            var despesasPorMes = await _context.Despesas
                .GroupBy(d => new { d.Data.Year, d.Data.Month })
                .Select(g => new { Ano = g.Key.Year, Mês = g.Key.Month, Total = g.Sum(d => d.Valor) })
                .ToListAsync();

            return Json(despesasPorMes);
        }

    }
}
