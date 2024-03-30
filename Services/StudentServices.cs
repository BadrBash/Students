using PracticeMVC.Data.Entities;
namespace PracticeMVC.Services
{

    public class StudentService
    {
        private readonly Data.AppDbContext _context;

        public StudentService(Data.AppDbContext context)
        {
            _context = context;
        }

        public List<Student> GetStudents()
        {
            // Retrieve students from the database
            return _context.Students.ToList();
        }

        public void Create(Student student)
        {
            // Add a new student to the database
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
    }

}
