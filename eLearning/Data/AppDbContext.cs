using Microsoft.EntityFrameworkCore;
using eLearning.Models;
using System;

namespace eLearning.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseImage> CourseImages { get; set; }
        public DbSet<InstructorSocial> InstructorSocials { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<InformationIcon> InformationIcons { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CourseStudent>()
                .HasKey(cs => new { cs.CourseId, cs.StudentId });

            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(cs => cs.CourseId);

            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.CourseStudents)
                .HasForeignKey(cs => cs.StudentId);
        }
    }
}
