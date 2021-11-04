using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        //In order to local test
        protected StudentSystemContext()
        {

        }

        //To use external connection. In the current context Judjge will use the constructor
        public StudentSystemContext([NotNull] DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        //Configure connection to my server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        //To configure database relations (DLL) (FluentAPI)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .IsUnicode(true);

            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
               .Property(s => s.Birthday)
               .IsRequired(false);

            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsUnicode(true);

            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsUnicode(true);

            modelBuilder.Entity<Resource>()
                .Property(r => r.Name)
                .IsUnicode(true);
            
            modelBuilder.Entity<Resource>()
                .Property(r => r.Url)
                .IsUnicode(false);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.CourseId, sc.StudentId });
        }
    }
}
