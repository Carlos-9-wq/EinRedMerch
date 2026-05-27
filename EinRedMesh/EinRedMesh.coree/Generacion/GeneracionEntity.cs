using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ein.Dtos;
namespace Ein.Entidades
{
    [Table("Generacion")]
    public class GeneracionEntity
    {
        [Key]public int Id { get; set; }
        [Required,StringLength(12)]public string Nombre { get; set; }=string.Empty;
        [Required]public bool EstaActivo { get; set; }

    }
}
