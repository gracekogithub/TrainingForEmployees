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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
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
            //base.OnModelCreating(builder);
            //builder.Entity<PostUpdate>()
            // .HasData(
            //    new PostUpdate { PostUpdateId = 1, Daily = "Reminder", DailyContent = "We have a Cap inspection", DailyCreated = DateTime.Now },
            //    new PostUpdate { PostUpdateId = 2, Weekly = "Weekly Hightlight", WeeklyContent = "Will be posted", WeeklyCreated = DateTime.Now }
            //    );
        }
    }
}
