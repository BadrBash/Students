namespace PracticeMVC.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = default!;
        public string ContactNumber { get; set; } = default!;
        public string Department { get; set; } = default!;
    }
}
