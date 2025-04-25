using System.Data;
using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();

        categoriasInit.Add(new Categoria(){ 
            CategoriaId = Guid.Parse("0b91893e-3849-4fcf-bcd6-0f7740c7a5d7"), 
            Nombre = "Actividades pendientes", 
            Peso = 20
            });

        categoriasInit.Add(new Categoria(){ 
            CategoriaId = Guid.Parse("0b91893e-3849-4fcf-bcd6-0f7740c7a502"), 
            Nombre = "Actividades personales", 
            Peso = 50
            });


        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);

            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);

            categoria.Property(p=> p.Descripcion).IsRequired(false);

            categoria.Property(p=> p.Peso);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea(){
            TareaId = Guid.Parse("0b91893e-3849-4fcf-bcd6-0f7740c7a5f4"),
            CategoriaId = Guid.Parse("0b91893e-3849-4fcf-bcd6-0f7740c7a5d7"),
            PrioridadTarea = Prioridad.Media,
            Titulo = "Pago de servicios publicos",
            FechaCreacion = new DateTime(2024, 7, 8)
        });
    
        tareasInit.Add(new Tarea(){
            TareaId = Guid.Parse("0b91893e-3849-4fcf-bcd6-0f7740c7a545"),
            CategoriaId = Guid.Parse("0b91893e-3849-4fcf-bcd6-0f7740c7a502"),
            PrioridadTarea = Prioridad.Baja,
            Titulo = "Terminar de ver peliculas en Netflix",
            FechaCreacion = new DateTime(2024, 5, 3)
        });

        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.TareaId);

            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);

            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);

            tarea.Property(p=> p.Descripcion).IsRequired(false);

            tarea.Property(p=> p.PrioridadTarea);

            tarea.Property(p=> p.FechaCreacion);

            tarea.Ignore(p=> p.Resumen);

            tarea.HasData(tareasInit);
        });
    }
}