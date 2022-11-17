using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoEF.Contexto;

var builder = WebApplication.CreateBuilder(args);

//antes de contruir la app vamos a preparar el entorno de EF

builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//creamos un endpoint para validar que todo este bien
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());

});

app.Run();
