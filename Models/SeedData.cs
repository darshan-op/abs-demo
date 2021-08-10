using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcList.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcListContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcListContext>>()))
            {
                // Look for any movies.
                if (context.List.Any())
                {
                    return;   // DB has been seeded
                }

                context.List.AddRange(
                    new List
                    {
                        FirstName = "Darshan",
                        LastName = "Shah",
                        Age = 22
                    },

                    new List
                    {
                        FirstName = "Dishank",
                        LastName = "Shah",
                        Age = 19
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
