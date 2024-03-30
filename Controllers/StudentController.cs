using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeMVC.Data;
using PracticeMVC.Data.Entities;
using PracticeMVC.Models;

namespace PracticeMVC.Controllers;

public class StudentController : Controller
{
    private readonly Services.StudentService _services;

    private readonly AppDbContext _context;

    public StudentController(AppDbContext appDbContext, Services.StudentService services)
    {
        _context = appDbContext;
        _services = services;
    }

    //GET: Student
    public IActionResult Index()
    {
        var result = _context.Students.Select(x => new StudentViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            ContactNumber = x.ContactNumber
        }).ToList();

        return View(result);
    }

    //GET: Student
    public IActionResult Create()
    {
        return View();
    }

    // POST: Student/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateStudentViewModel request)
    {
        var isEmailExist = _context.Students.Any(x => x.Email == request.Email);

        if (isEmailExist)
        {
            ViewBag.ErrorMessage = "Email already exsits!.";
            return View(request);
        }

        if (ModelState.IsValid)
        {
            var student = new Student
            {
                Name = request.Name,
                ContactNumber = request.ContactNumber,
                Email = request.Email,
            };
            _context.Students.Add(student);
            _context.SaveChanges();
            ViewData["SuccessMessage"] = "Student created successfully!";
            return RedirectToAction("Index", "Student");
        }
        return View();

    }

    // GET: Student/Edit/5
    public IActionResult Edit(int id)
    {
        var student = _context.Students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        var viewModel = new StudentViewModel
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            ContactNumber = student.ContactNumber
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(StudentViewModel request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var student = _context.Students.FirstOrDefault(s => s.Id == request.Id);

        if (student == null)
        {
            return NotFound();
        }

        student.Name = request.Name;
        student.Email = request.Email;
        student.ContactNumber = request.ContactNumber;

        try
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while updating the student record.");
        }

        return RedirectToAction("Index","Student");
    }



    /*// POST: Student/Delete/5
    [HttpDelete]
    [ValidateAntiForgeryToken]
    public IActionResult Delete([FromRoute] int id)
    {
        var request = _context.Students.Find(id);

        if (request == null)
        {
            return NotFound();
        }

        _context.Students.Remove(request);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }*/

    [HttpDelete]
    [ValidateAntiForgeryToken]
    public IActionResult Delete([FromRoute]int id)
    {
        var student = _context.Students.Find(id);

        if (student == null)
        {
            return NotFound();
        }

        try
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while deleting the student record.");
        }

        return RedirectToAction("Index", "");
    }

}