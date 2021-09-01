using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeTimeTracker.Models;

namespace EmployeeTimeTracker.Data
{
    public class EmployeeTimeTrackerContext : DbContext
    {
        public EmployeeTimeTrackerContext (DbContextOptions<EmployeeTimeTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeTimeTracker.Models.tbl_employees> tbl_employees { get; set; }

        public DbSet<EmployeeTimeTracker.Models.tbl_TimeForm> tbl_TimeForm { get; set; }

    }
}     
