using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodTruckAdminTools_v2.Models;

namespace FoodTruckAdminTools_v2.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly FoodTruckCompanyContext _context;

        public PersonalInfoController(FoodTruckCompanyContext context)
        {
            _context = context;    
        }

        // GET: PersonalInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalInfo.ToListAsync());
        }

        // GET: PersonalInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInfo = await _context.PersonalInfo
                .SingleOrDefaultAsync(m => m.ID == id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            return View(personalInfo);
        }

        // GET: PersonalInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,MiddleName,SSN,DateOfBirth,RoleId")] PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(personalInfo);
        }

        // GET: PersonalInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInfo = await _context.PersonalInfo.SingleOrDefaultAsync(m => m.ID == id);
            if (personalInfo == null)
            {
                return NotFound();
            }
            return View(personalInfo);
        }

        // POST: PersonalInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,MiddleName,SSN,DateOfBirth,RoleId")] PersonalInfo personalInfo)
        {
            if (id != personalInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalInfoExists(personalInfo.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(personalInfo);
        }

        // GET: PersonalInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInfo = await _context.PersonalInfo
                .SingleOrDefaultAsync(m => m.ID == id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            return View(personalInfo);
        }

        // POST: PersonalInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalInfo = await _context.PersonalInfo.SingleOrDefaultAsync(m => m.ID == id);
            _context.PersonalInfo.Remove(personalInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PersonalInfoExists(int id)
        {
            return _context.PersonalInfo.Any(e => e.ID == id);
        }
    }
}
