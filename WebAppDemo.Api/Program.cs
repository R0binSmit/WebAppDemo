using Microsoft.EntityFrameworkCore;
using Serilog;
using WebAppDemo.BusinessLogic.Helper;
using WebAppDemo.BusinessLogic.Repositories;
using WebAppDemo.DataAccess;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.IBusinessLogic.Interfaces.Repositories;
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

// Add Mappers.
builder.Services.AddSingleton<IVacationTypeMapper, VacationTypeMapper>();

// Add Logging
builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
