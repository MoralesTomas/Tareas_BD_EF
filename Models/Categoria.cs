using System.ComponentModel.DataAnnotations;

namespace proyectoEF.Models;

public class Categoria
{
    //usando DataAnnotations
    // [Key] ya no se utilizara las dataAnnotations y en su lugar se usara Fluent API
    public Guid CategoriaID { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    //esta propiedad es para relacionar las tareas que esten en dicha categoria
    public virtual ICollection<Tarea> Tareas {get;set;}

}
