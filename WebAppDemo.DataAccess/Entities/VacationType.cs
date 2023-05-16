using Microsoft.EntityFrameworkCore;
using WebAppDemo.DataAccess.EntityConfigurations;

namespace WebAppDemo.DataAccess.Entities;

[EntityTypeConfiguration(typeof(VacationTypeConfiguration))]
public  class VacationType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
