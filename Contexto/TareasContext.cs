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

    protected override void  OnModelCreating(ModelBuilder modelBuilder){
        /*
        Para las categorias, esto es una manera de hacer restricciones para cada atributo sin usar dataAnnotation
        algunas definiciones quedaran aca.
        lo que hacemos es definir el modelo de la construccion de cada tabla.
        */

        modelBuilder.Entity<Categoria>(categoria =>{
            //definiendo el nombre de la tabla y que se convertira en una tabla
            categoria.ToTable("Categoria");

            //esto es para el Primary Key y le asignamos el atributo
            categoria.HasKey(cat => cat.CategoriaID);

            //esto es para definir las propiedades.
            //recordemos que es bueno definirlas aunque si no lo hacemos EF igual hara el mapeo de todo
            //se define para un mejor control.

            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);

            categoria.Property(p => p.Descripcion).IsRequired().HasMaxLength(250);

        });

        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");

            tarea.HasKey(p=> p.TareaId);

            //definiendo la relacion de uno a muchos y la FK
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaID);

            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);

            tarea.Property(p=> p.Descripcion);

            tarea.Property(p=> p.PrioridadTarea);

            tarea.Property(p=> p.FechaCreacion);

            //para que no haga el mapeo de la propiedad resumen

            tarea.Ignore(p=> p.Resumen);

        });

    }
    
}
#region explicacionTarea
/*
//las relaciones son importantes es decir la relacion de uno a muchos o de uno a uno o de mucho a muchos.

//estas relaciones las hicimos mediante metodos virtuales aunque puede que no sean necesarios.

	//#Clave1911 Estas relaciones las podemos hacer de:

		>uno a uno (solo un objeto como una propiedad dentro de una clase siendo este objeto otra clase)

		>uno a muchos(declaramos una propiedad como una coleccion de objetos haciendo referencia a otra clase.)

	y en el contexto se haria lo siguiente:
	//recordar que la relacion antes mencionada debe existir

	tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=>p.CategoriaId);

	Donde:

		>HasOne(<1>)

			indica la relacion de uno y recive quien es ese uno, es decir su clase mediante una funcion de lambda.

			Es decir que pasamos como parametro la relacion que se meciono anteriormente #Clave1911

			sintaxis:

				//es mediante una funcion lambda

				1:
					p=> p.Relacion

		>WithMany(<2>)

			indica la relacion de muchos y recive la relacion que se menciono anteriormente #clave1911 pero de la clase que mandamos en el hasOne es decir es la otra relacion

			sintaxis:

				//es mediante una funcion lambda 

				p=> p.Relacion

		>HasForeignKey(<3>) 

			Indica la llave foranea que es la que hace posible esta relacion y recibe como parametro el atributo que contiene el ID de la relacion es decir que esta clase debe contener algo como "int myID" y algo como "relacionID" el cual hace referencia a la llave de la relacion. 

			sintaxis:

				//esto es mediante una funcion de lambda.

				p=> p.NombreDePK


	//esto no solo indica que existe una clave foranea sino que indica la relacion que existe entre ambos campos de los dos modelos
*/
#endregion Fin explicacionTarea