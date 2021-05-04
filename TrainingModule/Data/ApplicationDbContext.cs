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
            Database.Migrate();
        }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Update> PostUpdates { get; set; }
        public virtual DbSet<ManagerFeedback> ManagerFeedbacks { get; set; }
        public virtual DbSet<ManagerTraining> ManagerTrainings { get; set; }
        public virtual DbSet<ManagerUpdate> ManagerUpdates { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<EmployeeFeedback> EmployeeFeedbacks { get; set; }

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
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ManagerFeedback>()
             .HasKey(fe => new { fe.FeedbackId, fe.ManagerId });
            modelBuilder.Entity<ManagerFeedback>()
                .HasOne(m => m.Manager)
                .WithMany(ma => ma.ManagerFeedbacks)
                .HasForeignKey(m => m.ManagerId);
            modelBuilder.Entity<ManagerFeedback>()
                .HasOne(m => m.Feedback)
                .WithMany(me => me.ManagerFeedbacks)
                .HasForeignKey(m => m.FeedbackId);
            modelBuilder.Entity<EmployeeFeedback>()
             .HasKey(fe => new { fe.FeedbackId, fe.EmployeeId });
            modelBuilder.Entity<EmployeeFeedback>()
                .HasOne(m => m.Employee)
                .WithMany(ef => ef.EmployeeFeebacks)
                .HasForeignKey(m => m.EmployeeId);
            modelBuilder.Entity<EmployeeFeedback>()
                .HasOne(m => m.Feedback)
                .WithMany(ef => ef.EmployeeFeedbacks)
                .HasForeignKey(m => m.FeedbackId);
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ManagerUpdate>()
             .HasKey(p => new { p.UpdateId, p.ManagerId });
            modelBuilder.Entity<ManagerUpdate>()
                .HasOne(u => u.Manager)
                .WithMany(up => up.ManagerUpdates)
                .HasForeignKey(u => u.ManagerId);
            modelBuilder.Entity<ManagerUpdate>()
                .HasOne(u => u.Update)
                .WithMany(mu => mu.ManagerUpdates)
                .HasForeignKey(u => u.UpdateId);
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ManagerTraining>()
             .HasKey(p => new { p.TrainingId, p.ManagerId });
            modelBuilder.Entity<ManagerTraining>()
                .HasOne(t => t.Manager)
                .WithMany(tr => tr.ManagerTrainings)
                .HasForeignKey(t => t.ManagerId);
            modelBuilder.Entity<ManagerTraining>()
                .HasOne(t => t.Manager)
                .WithMany(mr => mr.ManagerTrainings)
                .HasForeignKey(t => t.TrainingId);

        }
    }
}
