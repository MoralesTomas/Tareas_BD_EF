using Microsoft.EntityFrameworkCore;
using proyectoEF.Models;

namespace   proyectoEF.Contexto;


//vamos a heredar de DBcontext para poder hacer uso de EF
public class TareasContext:DbContext
{

    
    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Tarea> Tareas { get; set; }

    //creamos un constructorcon las configuraciones que yat

    public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }
    
}