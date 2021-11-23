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
    public class DeliveryTeamsController : Controller
    {
        private readonly UCP1Context _context;

        public DeliveryTeamsController(UCP1Context context)
        {
            _context = context;
        }

        // GET: DeliveryTeams
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeliveryTeams.ToListAsync());
        }

        // GET: DeliveryTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryTeam = await _context.DeliveryTeams
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (deliveryTeam == null)
            {
                return NotFound();
            }

            return View(deliveryTeam);
        }

        // GET: DeliveryTeams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeliveryTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,NameEmployee,Email")] DeliveryTeam deliveryTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryTeam);
        }

        // GET: DeliveryTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryTeam = await _context.DeliveryTeams.FindAsync(id);
            if (deliveryTeam == null)
            {
                return NotFound();
            }
            return View(deliveryTeam);
        }

        // POST: DeliveryTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,NameEmployee,Email")] DeliveryTeam deliveryTeam)
        {
            if (id != deliveryTeam.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryTeamExists(deliveryTeam.EmployeeId))
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
            return View(deliveryTeam);
        }

        // GET: DeliveryTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryTeam = await _context.DeliveryTeams
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (deliveryTeam == null)
            {
                return NotFound();
            }

            return View(deliveryTeam);
        }

        // POST: DeliveryTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryTeam = await _context.DeliveryTeams.FindAsync(id);
            _context.DeliveryTeams.Remove(deliveryTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryTeamExists(int id)
        {
            return _context.DeliveryTeams.Any(e => e.EmployeeId == id);
        }
    }
}
