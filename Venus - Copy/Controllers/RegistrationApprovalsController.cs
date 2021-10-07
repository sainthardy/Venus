using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Venus.Data;
using Venus.Models;

namespace Venus.Controllers
{
    public class RegistrationApprovalsController : Controller
    {
        private readonly VenusContext _context;

        public RegistrationApprovalsController(VenusContext context)
        {
            _context = context;
        }

        // GET: RegistrationApprovals
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistrationApproval.ToListAsync());
        }

        // GET: RegistrationApprovals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationApproval = await _context.RegistrationApproval
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrationApproval == null)
            {
                return NotFound();
            }

            return View(registrationApproval);
        }

        // GET: RegistrationApprovals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistrationApprovals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,Address,ZipCode,Telephone,Fax,NPWP,FieldOfBusiness,PICName,PICEmail")] RegistrationApproval registrationApproval)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrationApproval);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registrationApproval);
        }

        // GET: RegistrationApprovals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationApproval = await _context.RegistrationApproval.FindAsync(id);
            if (registrationApproval == null)
            {
                return NotFound();
            }
            return View(registrationApproval);
        }

        // POST: RegistrationApprovals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,Address,ZipCode,Telephone,Fax,NPWP,FieldOfBusiness,PICName,PICEmail")] RegistrationApproval registrationApproval)
        {
            if (id != registrationApproval.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrationApproval);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationApprovalExists(registrationApproval.Id))
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
            return View(registrationApproval);
        }

        // GET: RegistrationApprovals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationApproval = await _context.RegistrationApproval
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrationApproval == null)
            {
                return NotFound();
            }

            return View(registrationApproval);
        }

        // POST: RegistrationApprovals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrationApproval = await _context.RegistrationApproval.FindAsync(id);
            _context.RegistrationApproval.Remove(registrationApproval);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationApprovalExists(int id)
        {
            return _context.RegistrationApproval.Any(e => e.Id == id);
        }
    }
}
