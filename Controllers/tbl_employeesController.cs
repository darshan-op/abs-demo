using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeTimeTracker.Data;
using EmployeeTimeTracker.Models;

namespace EmployeeTimeTracker.Controllers
{
    public class tbl_employeesController : Controller
    {
        private readonly EmployeeTimeTrackerContext _context;

        public tbl_employeesController(EmployeeTimeTrackerContext context)
        {
            _context = context;
        }

        // GET: tbl_employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_employees.ToListAsync());
        }

        // GET: tbl_employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_employees = await _context.tbl_employees
                .FirstOrDefaultAsync(m => m.emp_ID == id);
            if (tbl_employees == null)
            {
                return NotFound();
            }

            return View(tbl_employees);
        }

        // GET: tbl_employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tbl_employees/Create   
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("emp_ID,email,password,name,gender,hobbies,skill,address,city,state,country,postal_code")] tbl_employees tbl_employees)
        {
            if (ModelState.IsValid)
            {
                var ver = _context.tbl_employees.FirstOrDefault(x => x.email.Equals(tbl_employees.email));
                if (ver==null)
                {
                    _context.Add(tbl_employees);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                } else
                {
                    ViewBag.err = "Email is already used";
                }
               
            }
            return View(tbl_employees);
        }

        // GET: tbl_employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_employees = await _context.tbl_employees.FindAsync(id);
            if (tbl_employees == null)
            {
                return NotFound();
            }
            return View(tbl_employees);
        }

        // POST: tbl_employees/Edit/5
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("emp_ID,email,password,name,gender,hobbies,skill,address,city,state,country,postal_code")] tbl_employees tbl_employees)
        {
            if (id != tbl_employees.emp_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbl_employees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbl_employeesExists(tbl_employees.emp_ID))
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
            return View(tbl_employees);
        }

        // GET: tbl_employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_employees = await _context.tbl_employees
                .FirstOrDefaultAsync(m => m.emp_ID == id);
            if (tbl_employees == null)
            {
                return NotFound();
            }

            return View(tbl_employees);
        }

        // POST: tbl_employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbl_employees = await _context.tbl_employees.FindAsync(id);
            _context.tbl_employees.Remove(tbl_employees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbl_employeesExists(int id)
        {
            return _context.tbl_employees.Any(e => e.emp_ID == id);
        }

        //public bool Update(string password,tbl_employees tbl_emp)
        //{
        //    using (var context = new  _context)
        //    {

        //    }


        //}
    }
}
