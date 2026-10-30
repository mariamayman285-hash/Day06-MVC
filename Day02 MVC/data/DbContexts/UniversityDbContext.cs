using Day02_MVC.Models;
using Microsoft.EntityFrameworkCore;
namespace Day02_MVC.data.DbContexts

{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) :base(options)  //???
        {
        }

        public UniversityDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=University;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StuCrsRes> StuCrsReses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StuCrsRes>()
                        .HasKey(SCR => new {SCR.StudentId,SCR.CourseId});
        }

    }
    
}