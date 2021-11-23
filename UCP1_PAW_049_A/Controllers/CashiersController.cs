using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_049_A.Models;

namespace UCP1_PAW_049_A.Controllers
{
    public class CashiersController : Controller
    {
        private readonly UCP1Context _context;

        public CashiersController(UCP1Context context)
        {
            _context = context;
        }

        // GET: Cashiers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cashiers.ToListAsync());
        }

        // GET: Cashiers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashier = await _context.Cashiers
                .FirstOrDefaultAsync(m => m.IdCashier == id);
            if (cashier == null)
            {
                return NotFound();
            }

            return View(cashier);
        }

        // GET: Cashiers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cashiers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCashier,NamaKasir,Email")] Cashier cashier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cashier);
        }

        // GET: Cashiers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashier = await _context.Cashiers.FindAsync(id);
            if (cashier == null)
            {
                return NotFound();
            }
            return View(cashier);
        }

        // POST: Cashiers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCashier,NamaKasir,Email")] Cashier cashier)
        {
            if (id != cashier.IdCashier)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashierExists(cashier.IdCashier))
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
            return View(cashier);
        }

        // GET: Cashiers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashier = await _context.Cashiers
                .FirstOrDefaultAsync(m => m.IdCashier == id);
            if (cashier == null)
            {
                return NotFound();
            }

            return View(cashier);
        }

        // POST: Cashiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashier = await _context.Cashiers.FindAsync(id);
            _context.Cashiers.Remove(cashier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashierExists(int id)
        {
            return _context.Cashiers.Any(e => e.IdCashier == id);
        }
    }
}
