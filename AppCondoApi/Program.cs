using AppCondo.Application.Interfaces;
using AppCondo.Application.Mappings.Doorman;
using AppCondo.Application.Services.PorteiroService;
using AppCondo.Data.Context;
using AppCondo.Data.Repositories;
using AppCondo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
    ));


builder.Services.AddScoped<IDoormanRepository, DoormanRepository>();
builder.Services.AddScoped<IDoormanMap, DoormanMap>();
builder.Services.AddScoped<IDoormanService, DoormanService>();
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
