using Microsoft.EntityFrameworkCore;
using WebAppDemo.AbsenceService.DataAccess;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataAccess.Repositories;
using WebAppDemo.AbsenceService.IDataAccess;
using WebAppDemo.AbsenceService.IMappers;
using WebAppDemo.AbsenceService.Mappers;

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

// Add Mappers
builder.Services.AddSingleton<IAbsenceMapper, AbsenceMapper>();
builder.Services.AddSingleton<IAbsenceTypeMapper, AbsenceTypeMapper>();
builder.Services.AddSingleton<IAddressMapper, AddressMapper>();
builder.Services.AddSingleton<ICountryMapper, CountryMapper>();
builder.Services.AddSingleton<IEmployeeMapper, EmployeeMapper>();
builder.Services.AddSingleton<IStateMapper, StateMapper>();

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
