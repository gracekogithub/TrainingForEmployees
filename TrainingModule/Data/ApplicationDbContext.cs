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
            //Database.Migrate();
        }
        public DbSet<Training> Trainings { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Update> Updates { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                  
                    Id = "b16d5f56-9d3b-4b23-810b-337e8e07ec0e",
                    Name = "Manager",
                    NormalizedName = "MANAGER",
                    ConcurrencyStamp = "37bccd01-d902-407e-88ba-5e871808e364"
                },
                new IdentityRole
                {
                    Id= "f6564e9f-7907-4caa-b010-f5f46a3d8bc8",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                    ConcurrencyStamp= "cd287cc4-9d7f-4b93-b769-5ca418a0b56b"
                });
           
            //many to may relationship for multiple trainer
           
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<ManagerTraining>()
            // .HasKey(p => new { p.TrainingId, p.ManagerId });
            //modelBuilder.Entity<ManagerTraining>()
            //    .HasOne(t => t.Manager)
            //    .WithMany(tr => tr.ManagerTrainings)
            //    .HasForeignKey(t => t.ManagerId);
            //modelBuilder.Entity<ManagerTraining>()
            //    .HasOne(t => t.Manager)
            //    .WithMany(mr => mr.ManagerTrainings)
            //    .HasForeignKey(t => t.TrainingId);

        }
    }
}
