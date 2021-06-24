using Demo.DAL.Configurations;
using Demo.Models;
using Demo.Models.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.DAL.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            base.OnModelCreating(modelBuilder); 
        }
        public override int SaveChanges()
        {
            UpdateEntitiesInfo();
            return base.SaveChanges();
        }

        public  async Task<int> SaveChangesAsync()
        {
            UpdateEntitiesInfo();
            return  await base.SaveChangesAsync();
        }
        private void UpdateEntitiesInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State==EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}
