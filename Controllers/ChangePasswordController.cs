using EmployeeTimeTracker.Data;
using EmployeeTimeTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTimeTracker.Controllers
{
    public class ChangePasswordController : Controller
    {
        private readonly EmployeeTimeTrackerContext _context;
        public ChangePasswordController(EmployeeTimeTrackerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Update(tbl_employees tbl_employees)
        {
            var uptd_pass = _context.tbl_employees.FirstOrDefault(x => x.email.Equals(tbl_employees.email) && x.password.Equals(tbl_employees.password));
            if (uptd_pass == null)
            {
                return NotFound();
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(tbl_employees tbl_employees, ChangePassword changePassword)
        {

            var uptd_pass = _context.tbl_employees.FirstOrDefault(x => x.email == tbl_employees.email);
            uptd_pass.password = changePassword.New_Password;
            _context.tbl_employees.Update(uptd_pass);
            _context.SaveChanges();



            ViewBag.ErrorMessage = "";
            return RedirectToAction("Index", "ChangePassword");
            //ViewBag.errmsg = "Email not found or old Password did not matched";
        }
    }

}
    

