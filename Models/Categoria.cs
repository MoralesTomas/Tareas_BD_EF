using System.ComponentModel.DataAnnotations;

namespace proyectoEF.Models;

public class Categoria
{
    //usando DataAnnotations
    [Key]
    public Guid CategoriaID { get; set; }

    [Required]
    [MaxLength(150)]

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    //esta propiedad es para relacionar las tareas que esten en dicha categoria
    public virtual ICollection<Tarea> Tareas {get;set;}

}
