using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoEF.Contexto;
using proyectoEF.Models;

var builder = WebApplication.CreateBuilder(args);

//antes de contruir la app vamos a preparar el entorno de EF
//ahora vamos a hacer la conexion a una BD de sql server local 

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
//recordar que solo puede haber una configuracion de services por cada contexto.

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

//creamos un endpoint para validar que todo este bien
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();

    //aca deberia tirar error poque ya no tenemos la BD en memoria pero si en el servidor de sql 
    //es decir podriamos ver la BD en el servidor sql server
    return Results.Ok("Base de datos en memoria?: " + dbContext.Database.IsInMemory());

});

//consumiendo la app

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Tareas.Include(p=> p.Categoria).Where(p=> p.PrioridadTarea == proyectoEF.Models.TiposPrioridad.Baja));
});

//Post para agregar datos
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea)=>
{

    //por si no viene en el post le asignamos un nuevo ID y una fecha, en caso de que si venga 
    //se sobreescribe
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    //esto es para agregarlo de manera asincrona y el await es para que espere a que termine
    await dbContext.AddAsync(tarea);
    //await dbContext.Tareas.AddAsync(tarea);

    await dbContext.SaveChangesAsync();

    return Results.Ok();   
});

app.Run();
