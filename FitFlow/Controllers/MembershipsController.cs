using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitFlow.Data;
using FitFlow.Models.Entities;

namespace FitFlow.Controllers
{
    public class MembershipsController : Controller
    {
        private readonly GymDbContext _context;

        public MembershipsController(GymDbContext context)
        {
            _context = context;
        }

        // GET: Memberships
        public async Task<IActionResult> Index()
        {
            var memberships = _context.Memberships
                .Include(m => m.Person)
                .OrderBy(m => m.StartDate)
                .ToList();

            //return View(memberships);
            return View(await _context.Memberships.ToListAsync());
        }

        // GET: Memberships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var memberships = _context.Memberships
                .Include(m => m.Person)
                .OrderBy(m => m.StartDate)
                .ToList();

            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships
                .FirstOrDefaultAsync(m => m.MembershipID == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // GET: Memberships/Create
        public IActionResult Create()
        {
            var persons = _context.Persons
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToList();

            // Create SelectList for person dropdown using PersonID as value and FullName as display text
            ViewBag.PersonID = new SelectList(persons, "PersonID", "FullName");

            return View();
        }

            // POST: Memberships/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembershipID,PersonID,MembershipType,StartDate,EndDate,Fee")] Membership membership)
        {
            if (!string.IsNullOrEmpty(membership.MembershipType))
            {
                membership.MembershipType = membership.MembershipType.ToUpper();
            }

            // Check if the membership type is valid
            if (ModelState.IsValid)
            {
                // Check if a membership already exists for the selected person  
                var existingMembership = _context.Memberships
                   .Where(m => m.PersonID == membership.PersonID && m.MembershipType == membership.MembershipType)
                   .FirstOrDefault();

                if (existingMembership != null)
                {
                    ModelState.AddModelError("PersonID", "A membership already exists for the selected person.");

                    var personsList = _context.Persons
                       .OrderBy(p => p.LastName)
                       .ThenBy(p => p.FirstName)
                       .ToList();
                    
                    ViewBag.PersonID = new SelectList(personsList, "PersonID", "FullName", membership.PersonID);
                    return View(membership);
                }

                _context.Add(membership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var personsDropdown = _context.Persons
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToList();
            ViewBag.PersonID = new SelectList(personsDropdown, "PersonID", "FullName", membership.PersonID);
            return View(membership);
        }

        // GET: Memberships/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships
                .Include(m => m.Person)
                .FirstOrDefaultAsync(m => m.MembershipID == id);

            if (membership == null)
            {
                return NotFound();
            }

            var personsDropdown = _context.Persons
             .OrderBy(p => p.LastName)
             .ThenBy(p => p.FirstName)
             .ToList();
            ViewBag.PersonName = membership.Person?.FullName;
            ViewBag.PersonID = new SelectList(personsDropdown, "PersonID", "FullName", membership.PersonID);

            return View(membership);

        }

        // POST: Memberships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembershipID,PersonID,MembershipType,StartDate,EndDate,Fee")] Membership membership)
        {
            if (id != membership.MembershipID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Get the existing membership from the database
                    var existingMembership = await _context.Memberships
                        .FindAsync(membership.MembershipID);

                    if (existingMembership == null)
                    {
                        return NotFound();
                    }

                    // Update only the properties that should change
                    existingMembership.PersonID = membership.PersonID;
                    existingMembership.MembershipType = membership.MembershipType;
                    existingMembership.StartDate = membership.StartDate;
                    existingMembership.EndDate = membership.EndDate;
                    existingMembership.Fee = membership.Fee;

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershipExists(membership.MembershipID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Repopulate dropdown if model state is invalid
           
            var personsDropdown = _context.Persons
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToList();

            ViewBag.PersonID = new SelectList(personsDropdown, "PersonID", "FullName", membership.PersonID);
            return View(membership);
        }

        // GET: Memberships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var memberships = await _context.Memberships
                .Include(m => m.Person)
                .FirstOrDefaultAsync(m => m.MembershipID == id);

            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships
                .FirstOrDefaultAsync(m => m.MembershipID == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // POST: Memberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membership = await _context.Memberships.FindAsync(id);
            if (membership != null)
            {
                _context.Memberships.Remove(membership);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershipExists(int id) => _context.Memberships.Any(e => e.MembershipID == id);
       
    }
}
