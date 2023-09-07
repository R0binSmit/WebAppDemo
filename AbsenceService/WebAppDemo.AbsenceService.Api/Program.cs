using Microsoft.EntityFrameworkCore;
using WebAppDemo.AbsenceService.DataAccess;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataAccess.Repositories;
using WebAppDemo.AbsenceService.IDataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Context
builder.Services.AddDbContextFactory<DatabaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("CS_AbsanceService"),
        new MySqlServerVersion(builder.Configuration.GetValue<string>("MySqlServerVersion"))
    )
);

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("CS_AbsanceService"),
        new MySqlServerVersion(builder.Configuration.GetValue<string>("MySqlServerVersion"))
    )
);


// Add Repository scopes for accessing Data.
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAddressRepository<Address>, AddressRepository>();
builder.Services.AddScoped<ICountryRepository<Country>, CountryRepository>();
builder.Services.AddScoped<IEmployeeRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IStateRepository<State>, StateRepository>();
builder.Services.AddScoped<IAbsenceRepository<Absence>, AbsenceRepository>();
builder.Services.AddScoped<IAbsenceTypeRepository<AbsenceType>, AbsenceTypeRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
