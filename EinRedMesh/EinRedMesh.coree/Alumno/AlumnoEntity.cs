using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ein.Enumeradores;

namespace Ein.Entidades
{
    [Table("Alumno")]
    public class AlumnoEntity
    {
       [Key] public int Id {  get; set; }
       [StringLength(8), Required] public string NumeroCuenta { get; set; }
        [StringLength(30), Required] public string Nombre { get; set; } = string.Empty;
        [StringLength(30), Required] public string ApellidoPaterno { get; set; } = string.Empty;
        [StringLength(30), Required] public string ApellidoMaterno { get; set; } = string.Empty;
        [StringLength(30)] public DateTime FechaNacimiento { get; set; }
       [Required] public SexoEnum Sexo {  get; set; }
       [Required] public int IdGrupo { get; set; }
       [Required] public bool EstaActivo { get; set; }
       [ForeignKey("IdGrupo")] public virtual GrupoEntity Grupo { get; set; }
    }
}
