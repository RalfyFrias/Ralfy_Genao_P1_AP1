using System.ComponentModel.DataAnnotations;

namespace Ralfy_Genao_P1_AP1.Models
{
    public class Aporte
    {
        [Key] 
        public int AporteId { get; set; }
        [Required(ErrorMessage = "El Campo Descripción es obligatorio ")]
        public string Persona { get; set; }
        [Required(ErrorMessage = "El Campo Descripción es obligatorio ")]
        public string Observacion { get; set; }
        [Required(ErrorMessage = "El Campo Descripción es obligatorio ")]
        public decimal Monto { get; set; }
        [Required(ErrorMessage = "El Campo Descripción es obligatorio ")]
        public DateTime Fecha { get; set; }
    }
}
