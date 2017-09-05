using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodTruckAdminTools_v2.Models;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace FoodTruckAdminTools_v2.Controllers
{
    public class FoodTruckCompaniesController : Controller
    {
        private readonly FoodTruckCompanyContext _context;

        public FoodTruckCompaniesController(FoodTruckCompanyContext context)
        {
            _context = context;    
        }

        // GET: FoodTruckCompanies
        public async Task<IActionResult> Index()
        {
            var contactInfoList = new List<ContactInfo>();
            contactInfoList.Add(new ContactInfo()
            {
                Contact = "Email1",
                ContactType = ContactTypeEnum.Email,
                ContactTypeId = (int)ContactTypeEnum.Email,
                DisplayOrder = 1
            });
            contactInfoList.Add(new ContactInfo()
            {
                Contact = "Email2",
                ContactType = ContactTypeEnum.Email,
                ContactTypeId = (int)ContactTypeEnum.Email,
                DisplayOrder = 2
            });
            contactInfoList.Add(new ContactInfo()
            {
                Contact = "Facebook",
                ContactType = ContactTypeEnum.Facebook,
                ContactTypeId = (int)ContactTypeEnum.Facebook,
                DisplayOrder = 1
            });

            var a = Utilities.SerializeObject<List<ContactInfo>>(contactInfoList);

            return View(await _context.FoodTruckCompany.ToListAsync());
        }

       

        // GET: FoodTruckCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodTruckCompany = await _context.FoodTruckCompany
                .SingleOrDefaultAsync(m => m.ID == id);
            if (foodTruckCompany == null)
            {
                return NotFound();
            }

            return View(foodTruckCompany);
        }

        // GET: FoodTruckCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodTruckCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([
            Bind("ID,BusinessName,CompanyTypeName,PermitNumber,HasVegeterianFood,HasVigenFood,HasCatering,HealthCode,Description,AreaOfOperationString,AdditionalInfoString,MealTypeNames,CuisineCategoyNames")] FoodTruckCompany foodTruckCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodTruckCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(foodTruckCompany);
        }

        // GET: FoodTruckCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodTruckCompany = await _context.FoodTruckCompany.SingleOrDefaultAsync(m => m.ID == id);
            if (foodTruckCompany == null)
            {
                return NotFound();
            }
            return View(foodTruckCompany);
        }

        // POST: FoodTruckCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BusinessName,CompanyTypeName,PermitNumber,HasVegeterianFood,HasVigenFood,HasCatering,HealthCode,Description,AreaOfOperationString,AdditionalInfoString")] FoodTruckCompany foodTruckCompany)
        {
            if (id != foodTruckCompany.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodTruckCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodTruckCompanyExists(foodTruckCompany.ID))
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
            return View(foodTruckCompany);
        }

        // GET: FoodTruckCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodTruckCompany = await _context.FoodTruckCompany
                .SingleOrDefaultAsync(m => m.ID == id);
            if (foodTruckCompany == null)
            {
                return NotFound();
            }

            return View(foodTruckCompany);
        }

        // POST: FoodTruckCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodTruckCompany = await _context.FoodTruckCompany.SingleOrDefaultAsync(m => m.ID == id);
            _context.FoodTruckCompany.Remove(foodTruckCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FoodTruckCompanyExists(int id)
        {
            return _context.FoodTruckCompany.Any(e => e.ID == id);
        }
    }
}
