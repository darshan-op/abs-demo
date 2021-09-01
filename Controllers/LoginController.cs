using EmployeeTimeTracker.Data;
using EmployeeTimeTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTimeTracker.Controllers
{
    public class LoginController : Controller

    {
        private readonly EmployeeTimeTrackerContext _context;

        public LoginController(EmployeeTimeTrackerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        //get Employee
        public IActionResult Verify(tbl_employees tbl_Employees)
        {
            var ver = _context.tbl_employees.FirstOrDefault(x => x.email.Equals(tbl_Employees.email) && x.password.Equals(tbl_Employees.password));
            if (ver != null)
            {
                
                HttpContext.Session.SetString("email", tbl_Employees.email);
                return RedirectToAction("Index", "Home");
                //  return RedirectToAction("Create", "TimeForm");
            }
            else
            {
                ViewBag.error = "Invalid Email or Password";
                return RedirectToAction("Index", "Login");
            }

        }
    }
}

