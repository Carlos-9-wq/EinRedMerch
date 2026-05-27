using Ein.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Ein.Dtos
{
   
    public class GeneracionSetDto
    {
        [Required, StringLength(12)]
        public string Nombre { get; set; } = string.Empty;
    }

   
    public class GeneracionGetDto
    {

       
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}