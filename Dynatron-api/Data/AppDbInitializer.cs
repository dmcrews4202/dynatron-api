using System.Linq;
using System.Threading.Tasks;
using Dynatron_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;

namespace Dynatron_api.Data
{
    public class AppDbInitializer 
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();

                context.Database.EnsureCreated();

                if (!context.Customers.Any())
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        context.Customers.Add(
                            new Customer {
                                FirstName = String.Format("Freddy{0}",i),
                                LastName = String.Format("Freeloader{0}",i),
                                Email = "ff@ff.edu",
                                Created = DateTime.Now,
                                Updated = DateTime.Now
                            }
                        );
                    }
                    context.SaveChanges();
                }
            }

        }
    }
}