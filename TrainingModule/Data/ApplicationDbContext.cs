using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingModule.Models;

namespace TrainingModule.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Update> PostUpdates { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Material> Materials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Manager",
                    NormalizedName = "Manager"
                },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "Employee"
                });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comment>()
             .HasKey(fe => new { fe.EmployeeId, fe.ManagerId });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>()
             .HasKey(p => new { p.UpdateId, p.ManagerId });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Material>()
             .HasKey(p => new { p.TrainingId, p.ManagerId });

        }
    }
}
