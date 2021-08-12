using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCrud.Data;
using WebAppCrud.Models;

namespace WebAppCrud.Controllers
{
    public class tbl_DepartmentsController : Controller
    {
        private readonly WebAppCrudContext _context;

        public tbl_DepartmentsController(WebAppCrudContext context)
        {
            _context = context;
        }

        // GET: tbl_Departments
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_Departments.ToListAsync());
        }

        // GET: tbl_Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Departments = await _context.tbl_Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbl_Departments == null)
            {
                return NotFound();
            }

            return View(tbl_Departments);
        }

        // GET: tbl_Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tbl_Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Department")] tbl_Departments tbl_Departments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbl_Departments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbl_Departments);
        }

        // GET: tbl_Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Departments = await _context.tbl_Departments.FindAsync(id);
            if (tbl_Departments == null)
            {
                return NotFound();
            }
            return View(tbl_Departments);
        }

        // POST: tbl_Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Department")] tbl_Departments tbl_Departments)
        {
            if (id != tbl_Departments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbl_Departments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbl_DepartmentsExists(tbl_Departments.Id))
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
            return View(tbl_Departments);
        }

        // GET: tbl_Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Departments = await _context.tbl_Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbl_Departments == null)
            {
                return NotFound();
            }

            return View(tbl_Departments);
        }

        // POST: tbl_Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbl_Departments = await _context.tbl_Departments.FindAsync(id);
            _context.tbl_Departments.Remove(tbl_Departments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbl_DepartmentsExists(int id)
        {
            return _context.tbl_Departments.Any(e => e.Id == id);
        }
    }
}
