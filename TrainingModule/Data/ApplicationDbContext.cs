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
        public DbSet<ITrainingRepository> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Update> Updates { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Material> Materials { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
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
