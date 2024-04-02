using PracticeMVC.Data.Entities;

namespace PracticeMVC.Services.Interface
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudentById(int id);
        void Create(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }

}
