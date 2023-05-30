using Microsoft.EntityFrameworkCore;
using WebAppDemo.DataAccess.EntityConfigurations;
using WebAppDemo.IDataAccess.Entities;

namespace WebAppDemo.DataAccess.Entities;

[EntityTypeConfiguration(typeof(VacationTypeConfiguration))]
public  class VacationType : IVacationType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
