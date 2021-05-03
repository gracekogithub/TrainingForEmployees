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
        public DbSet<PostUpdate> PostUpdates { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Comment> Comments { get; set; }


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
                
        }
    }
}
