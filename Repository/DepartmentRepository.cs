using Microsoft.EntityFrameworkCore;
using PracticeMVC.Data.Entities;
using PracticeMVC.Data;
using PracticeMVC.Services.Interface;

namespace PracticeMVC.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Department GetStudentById(int id)
        {
            return _context.Departments.Find(id);
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

        public Department GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public void AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void UpdateDepartment(Department student)
        {
            throw new NotImplementedException();
        }

        public void DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }
    }
}
