using PracticeMVC.Data.Entities;
using PracticeMVC.DTOs;
using PracticeMVC.Services.Interface;

namespace PracticeMVC.Services
{

    public class StudentService : IStudentService
    {
        private readonly Data.AppDbContext _context;
        private readonly IStudentRepository _repository;

        public StudentService(Data.AppDbContext context, IStudentRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        

        public void Edit(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        /*public StudentDto GetStudentById(int studentId)
        {
            // Retrieve student data from the database
            Student student = _repository.GetStudentById(studentId);

            // Map Student entity to StudentDto
            StudentDto studentDto = new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                DateOfBirth = student.DateOfBirth,
                Email = student.Email
                // Map other properties as needed
            };
            return studentDto;



            void UpdateStudent(Student student)
            {
                var existingStudent = _context.Students.Find(student.Id);

                if (existingStudent == null)
                {
                    throw new ArgumentException("Student not found");
                }

                existingStudent.Name = student.Name;
                existingStudent.DateOfBirth = student.DateOfBirth;
                existingStudent.Email = student.Email;
                existingStudent.PhoneNumber = student.PhoneNumber;
                existingStudent.Department = student.Department;

                _context.SaveChanges();
            }


            void DeleteStudent(int id)
            {
                var studentToDelete = _context.Students.Find(id);

                if (studentToDelete == null)
                {
                    throw new ArgumentException("Student not found");
                }

                _context.Students.Remove(studentToDelete);

                _context.SaveChanges();
            }

        }*/

        Student IStudentService.GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        void IStudentService.UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        void IStudentService.DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }
    }

}