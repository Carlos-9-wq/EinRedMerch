using Microsoft.EntityFrameworkCore;
using Ein.Entidades;
using EinRedMesh.Data.AutoMapper;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(cfg  => cfg.AddProfile<AutoMapperProfile>());

builder.Services.AddDbContext<EinDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));
  
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
// Agregar los servicios de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Activar la interfaz de Swagger si estamos en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Esto es lo que genera el index.html de Swagger
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
