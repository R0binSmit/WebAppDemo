﻿namespace WebAppDemo.VacationService.DataAccess.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int AddressId { get; set; }
    public Address Address { get; set; } = default!;
    public List<Vacation> Vacations { get; set; } = default!;
}
