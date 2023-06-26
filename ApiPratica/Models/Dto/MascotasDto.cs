using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPratica.Models.Dto
{
    public class MascotasDto
    {
        public int MascotaId { get; set; }
        [Required]
        public string MascotaName { get; set; }

        public string MascotaDescription { get; set; }
        
        public DateTime Fecha { get; set; }
        [Required]

        public string RazaId { get; set; }

    }
}
