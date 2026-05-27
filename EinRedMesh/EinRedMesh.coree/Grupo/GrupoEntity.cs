using Ein.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ein.Entidades
{
    [Table("Grupo")]
    public class GrupoEntity
    {



        [Key] public int Id { get; set; }
        [Required] public int IdGeneracion { get; set; }
        [Required, StringLength(10)] public string Nombre { get; set; } = string.Empty;
        [Required] public bool EstaActivo { get; set; }
        [ForeignKey("IdGeneracion")] public virtual GeneracionEntity Generacion { get; set; }
    }
}