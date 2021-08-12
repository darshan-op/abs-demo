using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppCrud.Models;

namespace WebAppCrud.Data
{
    public class WebAppCrudContext : DbContext
    {
        public WebAppCrudContext (DbContextOptions<WebAppCrudContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppCrud.Models.tbl_Departments> tbl_Departments { get; set; }

        public DbSet<WebAppCrud.Models.tbl_Student> tbl_Student { get; set; }
    }
}
