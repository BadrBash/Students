using System.ComponentModel.DataAnnotations;

namespace PracticeMVC.Models;

public class StudentViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ContactNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
}

public class CreateStudentViewModel
{
    public string Name { get; set; } = default!;

    [Display(Name = "Contact Number")]
    [Required(ErrorMessage = "Contact number is required")]
    [Phone]
    public string ContactNumber { get; set; } = default!;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; } = default!;
}