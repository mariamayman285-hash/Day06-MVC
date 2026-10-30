using Day02_MVC.data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Day02_MVC.Models
{
    public class CourseBL
    {
        UniversityDbContext _context = new UniversityDbContext();

        public List<Course> GetAll()
        {
            return _context.Courses.Include(c => c.Department).ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Include(c => c.Department).FirstOrDefault(c => c.Id == id);
        }

        public void Insert(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = GetById(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
}
