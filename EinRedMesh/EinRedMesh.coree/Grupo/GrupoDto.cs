using Ein.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Ein.Dtos
{
    public class GrupoSetDto
    {
        [Required] public int IdGeneracion { get; set; }
        [Required, StringLength(10)] public string Nombre { get; set; } = string.Empty;
    }
    public class GrupoGetDto
    {

        [Key] public int Id { get; set; }
        [Required] public int IdGeneracion { get; set; }
        public string NombreGeneracion { get; set; } 
        [Required, StringLength(10)] public string Nombre { get; set; } = string.Empty;

    }


}
