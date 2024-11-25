using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvidencePojisteni.Data;
using EvidencePojisteni.Models;
using Microsoft.AspNetCore.Authorization;

namespace EvidencePojisteni.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class InsuredUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsuredUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InsuredUsers
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.InsuredUser.ToListAsync());
        }

        // GET: InsuredUsers/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuredUser = await _context.InsuredUser
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (insuredUser == null)
            {
                return NotFound();
            }

            var insurances = await _context.Insurance
                .Where(i => i.InsuredUserId == insuredUser.UserId)
                .ToListAsync();

            ViewData["Insurances"] = insurances;

            return View(insuredUser);
        }

        // GET: InsuredUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsuredUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,FirstName,LastName,Email,PhoneNumber,Adress,City,ZipCode")] InsuredUser insuredUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuredUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insuredUser);
        }

        // GET: InsuredUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuredUser = await _context.InsuredUser.FindAsync(id);
            if (insuredUser == null)
            {
                return NotFound();
            }
            return View(insuredUser);
        }

        // POST: InsuredUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FirstName,LastName,Email,PhoneNumber,Adress,City,ZipCode")] InsuredUser insuredUser)
        {
            if (id != insuredUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuredUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuredUserExists(insuredUser.UserId))
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
            return View(insuredUser);
        }

        // GET: InsuredUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuredUser = await _context.InsuredUser
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (insuredUser == null)
            {
                return NotFound();
            }

            return View(insuredUser);
        }

        // POST: InsuredUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuredUser = await _context.InsuredUser.FindAsync(id);
            if (insuredUser != null)
            {
                _context.InsuredUser.Remove(insuredUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuredUserExists(int id)
        {
            return _context.InsuredUser.Any(e => e.UserId == id);
        }
    }
}
