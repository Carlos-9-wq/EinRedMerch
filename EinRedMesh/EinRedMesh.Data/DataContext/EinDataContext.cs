using Microsoft.EntityFrameworkCore;
using Ein.Entidades;
public class EinDataContext:DbContext
{
    public EinDataContext(DbContextOptions<EinDataContext> options) : base(options)
    {

    }
    public DbSet<AlumnoEntity> Alumnos { get; set; }
    public DbSet<GeneracionEntity> Generacion { get; set; }
    public DbSet<GrupoEntity> Grupos { get; set; }
    public object Generaciones { get; set; }
    public object Grupo { get; set; }
}
