using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcList.Models;

namespace MvcList.Data
{
    public class MvcListContext : DbContext
    {
        public MvcListContext (DbContextOptions<MvcListContext> options)
            : base(options)
        {
        }

        public DbSet<MvcList.Models.List> List { get; set; }
    }
}
