using EmployeeTimeTracker.Data;
using EmployeeTimeTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EmployeeTimeTracker.Controllers
{
    public class tbl_TimeFormController : Controller
    {
        public readonly EmployeeTimeTrackerContext _context;

        public tbl_TimeFormController(EmployeeTimeTrackerContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var getEmail = HttpContext.Session.GetString("email");
            var getAgain = _context.tbl_employees.FirstOrDefault(x => x.email == getEmail);
            var getId = getAgain.emp_ID;
            var rec = _context.tbl_TimeForm.Where(x => x.emp_ID == getId);
            // var rec = _context.tbl_TimeForm.FirstOrDefault(x => x.emp_ID == getId);
            if (rec != null)
            {
                return View(_context.tbl_TimeForm.Where(x => x.emp_ID == getId));
            }
            return View();
        }



        public IActionResult Create()
        {
            var getEmail = HttpContext.Session.GetString("email");
            var getAgain = _context.tbl_employees.FirstOrDefault(x => x.email == getEmail);
            var getId = getAgain.emp_ID;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id", "Date", "Client", "Project", "Hours", "Task_Description", "emp_Id")] Models.tbl_TimeForm timeform)
        {
            var getEmail = HttpContext.Session.GetString("email");
            var getAgain = _context.tbl_employees.FirstOrDefault(x => x.email == getEmail);
            if (getEmail != null)
            {
                timeform.emp_ID = getAgain.emp_ID;
            }
            if (ModelState.IsValid)
            {
                _context.Add(timeform);
                _context.SaveChanges();
                return RedirectToAction("Index", "tbl_TimeForm");
            }
            else
            {
                return RedirectToAction("Create", "tbl_TimeForm");
            }

        }
    }
}