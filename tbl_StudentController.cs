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
    public class tbl_StudentController : Controller
    {
        private readonly WebAppCrudContext _context;

        public tbl_StudentController(WebAppCrudContext context)
        {
            _context = context;
        }

        // GET: tbl_Student
        public IActionResult Index()
        {
            var stdlist = from a in _context.tbl_Student
                              //join it to tbl_Departments
                          join b in _context.tbl_Departments
                          on a.DepId equals b.Id into Dep
                          from b in Dep.DefaultIfEmpty()
                          select new tbl_Student
                          {
                              Id = a.Id,
                              First_Name = a.First_Name,
                              Last_Name = a.Last_Name,
                              Email = a.Email,
                              Mobile = a.Mobile,
                              DepId = a.DepId,
                              Department=b==null?"":b.Department
                          };
            return View(stdlist);
        }

        // GET: tbl_Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Student = await _context.tbl_Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbl_Student == null)
            {
                return NotFound();
            }

            return View(tbl_Student);
        }

        // GET: tbl_Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tbl_Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,First_Name,Last_Name,Email,Mobile,DepId")] tbl_Student tbl_Student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbl_Student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbl_Student);
        }

        // GET: tbl_Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Student = await _context.tbl_Student.FindAsync(id);
            if (tbl_Student == null)
            {
                return NotFound();
            }
            return View(tbl_Student);
        }

        // POST: tbl_Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,First_Name,Last_Name,Email,Mobile,DepId")] tbl_Student tbl_Student)
        {
            if (id != tbl_Student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbl_Student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbl_StudentExists(tbl_Student.Id))
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
            return View(tbl_Student);
        }

        // GET: tbl_Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Student = await _context.tbl_Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbl_Student == null)
            {
                return NotFound();
            }

            return View(tbl_Student);
        }

        // POST: tbl_Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbl_Student = await _context.tbl_Student.FindAsync(id);
            _context.tbl_Student.Remove(tbl_Student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbl_StudentExists(int id)
        {
            return _context.tbl_Student.Any(e => e.Id == id);
        }
    }
}
