using PracticeMVC.Data.Entities;
using PracticeMVC.Services.Interface;
using PracticeMVC.DTOs;
using PracticeMVC.Data;

namespace PracticeMVC.Services
{

    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public Department GetDepartmentById(int id)
        {
            // Retrieve the department with the specified ID from the DbContext
            // Assuming "Department" is your entity representing a department
            return _context.Departments.FirstOrDefault(d => d.Id == id);
        }


        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public void CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }



        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(Department Id)
        {
            _context.Departments.Remove(Id);
            _context.SaveChanges();
        }

        List<Department> IDepartmentService.GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteDepartment(int Id)
        {
            throw new NotImplementedException();
        }


        /*List<Department> IDepartmentService.GetStudents()
        {
            throw new NotImplementedException();
        }

        Student IDepartmentService.GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        void IDepartmentService.CreateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        void IDepartmentService.UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        void IDepartmentService.DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }*/

    }

}
