using Microsoft.EntityFrameworkCore;
using Serilog;
using WebAppDemo.BusinessLogic.Helper;
using WebAppDemo.BusinessLogic.Repositories;
using WebAppDemo.DataAccess;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataAccess.Repositories;
using WebAppDemo.IBusinessLogic.Interfaces.Repositories;
using WebAppDemo.IDataAccess.Repositories;
using WebAppDemo.IMappers;
using WebAppDemo.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Context
builder.Services.AddDbContextFactory<DatabaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString(ConfigurationHelper.WebAppDemo),
        new MySqlServerVersion(builder.Configuration.GetValue<string>(ConfigurationHelper.MySqlServerVersion))
    )
); ;

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString(ConfigurationHelper.WebAppDemo),
        new MySqlServerVersion(builder.Configuration.GetValue<string>(ConfigurationHelper.MySqlServerVersion))
    )
);

// Add Repository scopes for accessing Data.
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IVacationTypeRepository<VacationType>, VacationTypeRepository>();
builder.Services.AddScoped<IStateRepository<State>, StateRepository>();
builder.Services.AddScoped<IAddressRepository<Address>, AddressRepository>();
builder.Services.AddScoped<ICountryRepoitory<Country>, CountryRepository>();

// Add Mappers.
builder.Services.AddSingleton<IVacationTypeMapper, VacationTypeMapper>();
builder.Services.AddSingleton<IStateMapper, StateMapper>();
builder.Services.AddSingleton<IAddressMapper, AddressMapper>();
builder.Services.AddSingleton<ICountryMapper, CountryMapper>();

// Add Logging
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Add Corse Service
builder.Services.AddCors(options => options.AddPolicy(name: "WebAppDemo",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("WebAppDemo");
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
