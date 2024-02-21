using Microsoft.EntityFrameworkCore;
using SistemaGestionBusiness.Services;
using SistemaGestionData.dataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CoderContext>(options =>
    options.UseSqlServer("Server=AV35351\\MSSQLSERVER2022; Database=coderhousetest; Trusted_Connection=True;")
);
DependencyInjectionService.RegisterServices(builder.Services);

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
