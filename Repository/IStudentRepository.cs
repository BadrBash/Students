using PracticeMVC.Data.Entities;

namespace PracticeMVC.Services.Interface
{
    public interface IStudentRepository
    {
        Student GetStudentById(int id);
        IEnumerable<Student> GetAllStudents();
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        
    }
}