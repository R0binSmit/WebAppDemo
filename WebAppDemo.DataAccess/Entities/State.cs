﻿namespace WebAppDemo.DataAccess.Entities;

public class State
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public Country Country { get; set; } = default!;
    public virtual List<Address> Addresses { get; set; } = default!;
}
