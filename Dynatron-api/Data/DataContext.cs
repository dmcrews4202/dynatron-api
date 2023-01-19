using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dynatron_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Dynatron_api.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }

    }
}