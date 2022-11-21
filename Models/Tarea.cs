using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoEF.Models;

public class Tarea
{

    //usando DataAnnotations
    // [Key]
    public Guid TareaId { get; set; }

    // [ForeignKey("CategoriaId")]
    public Guid CategoriaID { get; set; }

    // [Required]
    // [MaxLength(200)]
    public string Titulo { get; set; }

    public string Descripcion { get; set; }

    public TiposPrioridad PrioridadTarea  { get; set; }

    public DateTime FechaCreacion  { get; set; }

    ////esta propiedad es para relacionar las tareas que esten en dicha categoria
    public virtual Categoria Categoria {get;set;}

    /*
    La palabra clave virtual se utiliza para modificar un método, propiedad, 
    indizador o declaración de evento y permite invalidar cualquiera de estos
    elementos en una clase derivada.
    */

    // [NotMapped]
    //para que no se haga el Mapped basta con no declarar la propiedad
    public string Resumen {get;set;}

}
