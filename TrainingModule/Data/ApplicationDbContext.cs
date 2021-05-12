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


        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }

        public virtual DbSet<Update> Updates { get; set; }
        public virtual DbSet<Reviewer> Reviewers { get; set; }


        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<ReviewerTraining> ReviewerTrainings { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<TrainingDetail> TrainingDetails { get; set; }
   
    



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
            modelBuilder.Entity<Training>()
           .HasData(
                   new Training { TrainingId = 1, Title = "Hematology", Content = "Hematology AML" },
                   new Training { TrainingId = 2, Title = "Chemistry", Content = "Chemistry hepatitis"}
           );
            modelBuilder.Entity<Reviewer>()
          .HasData(
                  new Reviewer { ReviewerId = 1, Name = "Grace", Message = "Please write your comment for each training" },
                  new Reviewer { ReviewerId = 2, Name = "Grace", Message = "Please write your comment" }
          );
           
            //modelBuilder.Entity<ReviewerTraining>()
            // .HasKey(p => new { p.TrainingId, p.ReviewerId });
            //modelBuilder.Entity<ReviewerTraining>()
            //    .HasOne(p => p.Reviewer)
            //    .WithMany(tr => tr.ReviewerTrainings)
            //    .HasForeignKey(p => p.ReviewerId);
            //modelBuilder.Entity<ReviewerTraining>()
            //    .HasOne(p => p.Training)
            //    .WithMany(mr => mr.ReviewerTrainings)
            //    .HasForeignKey(p => p.TrainingId);

        }




    }
}
