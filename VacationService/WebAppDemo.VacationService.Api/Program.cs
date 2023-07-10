using Microsoft.EntityFrameworkCore;
using WebAppDemo.IGeneric;
using WebAppDemo.VacationService.DataAccess;
using WebAppDemo.VacationService.DataAccess.Entities;
using WebAppDemo.VacationService.DataAccess.Repositories;
using WebAppDemo.VacationService.IDataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Context
builder.Services.AddDbContextFactory<DatabaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("CS_VacationService"),
        new MySqlServerVersion(builder.Configuration.GetValue<string>("MySqlServerVersion"))
    )
);

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("CS_VacationService"),
        new MySqlServerVersion(builder.Configuration.GetValue<string>("MySqlServerVersion"))
    )
);


// Add Repository scopes for accessing Data.
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAddressRepository<Address>, AddressRepository>();
builder.Services.AddScoped<ICountryRepository<Country>, CountryRepository>();
builder.Services.AddScoped<IEmployeeRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IStateRepository<State>, StateRepository>();
builder.Services.AddScoped<IVacationRepository<Vacation>, VacationRepository>();
builder.Services.AddScoped<IVacationTypeRepository<VacationType>, VacationTypeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
