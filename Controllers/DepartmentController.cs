using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeMVC.Data;
using PracticeMVC.Data.Entities;
using PracticeMVC.Models;

namespace PracticeMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        //GET: Department
        public IActionResult Index()
        {
            var result = _context.Departments.Select(x => new DepartmentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();

            return View(result);
        }
        //GET: Department
        public IActionResult CreateDepartment()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDepartment(CreateDepartmentViewModel request)
        {
            var isDescriptionExist = _context.Departments.Any(x => x.Description == request.Description);

            if (isDescriptionExist)
            {
                ViewBag.ErrorMessage = "Department already exsits!.";
                return View(request);
            }

            if (ModelState.IsValid)
            {
                var department = new Department
                {
                    Name = request.Name,
                    Description = request.Description,
                };
                _context.Departments.Add(department);
                _context.SaveChanges();
                ViewData["SuccessMessage"] = "Department created successfully!";
                return RedirectToAction("Index", "Department");
            }
            return View();
        }
        public IActionResult Update(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == id );
            if (department == null)
            {
                return NotFound();
            }
            var viewModel = new DepartmentViewModel
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
            };
            return View(viewModel);
        }
        [HttpPut]
        public IActionResult Update(DepartmentViewModel request)
        {
            if(!ModelState.IsValid)
            {
                return View(request);
            }

            var department = _context.Departments.FirstOrDefault(de => de.Id == request.Id);
            if (request == null)
            {
                return NotFound();
            }
            department.Name = request.Name;
            department.Description = request.Description;
            try
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the student record.");
            }

            return RedirectToAction("Index", "Student");
        }
    }

 }
