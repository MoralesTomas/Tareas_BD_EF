using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace proyectoEF.Models;

public class Categoria
{
    //usando DataAnnotations
    // [Key] ya no se utilizara las dataAnnotations y en su lugar se usara Fluent API
    public Guid CategoriaID { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    //este peso es la cantidad de esfuerzo de la tarea
    public int Peso { get; set; }

    //esta propiedad es para relacionar las tareas que esten en dicha categoria
    //para que no se encicle hacemos que al retornar el json no nos lo muestre
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas {get;set;}

}
