using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoEF.Contexto;
using proyectoEF.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

#region comentarioParametros
    /*
        Parametros:
            Data source
                indica el string de conexion
            Initial Catalog
                Indica el nombre de nuestra BD
            id; password
                credenciales para el servicio de BD
            TrustServerCertificate
                esto es para indicar que el Data source es seguro en caso que no lo acepte
            Recordar que esto son malas practicas

    */
#endregion termina comentarioParametros

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();

    return Results.Ok("Base de datos en memoria?: " + dbContext.Database.IsInMemory());

});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Tareas.Include(p=> p.Categoria).Where(p=> p.PrioridadTarea == proyectoEF.Models.TiposPrioridad.Baja));
});


app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea)=>
{

    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    
    await dbContext.SaveChangesAsync();

    return Results.Ok();   
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea,[FromRoute] Guid id)=>
{
    var tareaActual = dbContext.Tareas.Find(id);

    if(tareaActual!=null)
    {
        tareaActual.CategoriaID = tarea.CategoriaID;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;

        await dbContext.SaveChangesAsync();

        return Results.Ok();

    }

    return Results.NotFound();   
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);

    if(tareaActual!=null)
    {
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();
