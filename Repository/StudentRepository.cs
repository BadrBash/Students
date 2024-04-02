using PracticeMVC.Data;
using PracticeMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using PracticeMVC.Services.Interface;

namespace PracticeMVC.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var studentToDelete = _context.Students.Find(id);
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
            }
        }

        // Implement other methods as needed
    }
}