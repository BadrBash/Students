using PracticeMVC.Data.Entities;

namespace PracticeMVC.Repository
{
    public interface IDepartmentRepository
    {
        Department GetDepartmentById(int id);
        IEnumerable<Department> GetAllDepartments();
        void AddDepartment(Department department);
        void UpdateDepartment(Department student);
        void DeleteDepartment(int id);
    }
}
