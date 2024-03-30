using System.ComponentModel.DataAnnotations;

namespace PracticeMVC.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }

    public class CreateDepartmentViewModel
    {
        public string Name { get; set; } = default!;

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department is required")]
        [Phone]
        public string Description { get; set; } = default!;
    }

}