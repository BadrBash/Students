using PracticeMVC.Data.Entities;

namespace PracticeMVC.Services.Interface
{
    public interface IDepartmentService
    {
        
        List <Department> GetDepartmentById(int id);
        public IEnumerable<Department> GetAllDepartments();
        void CreateDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int Id);
    }
}
