using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NewProject.Models;
using NewProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<EmployeeStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(EmployeeStoreDatabaseSettings)));

builder.Services.AddSingleton<IEmployeeDatabaseSettins>(sp => sp.GetRequiredService<IOptions<EmployeeStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("EmployeeStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<ivenueser, venueser>();
builder.Services.AddScoped<iZonesInterface, Zonesser>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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





