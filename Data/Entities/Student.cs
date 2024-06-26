﻿namespace PracticeMVC.Data.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ContactNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
}
