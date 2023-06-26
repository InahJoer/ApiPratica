using System.ComponentModel.DataAnnotations;

namespace ApiPratica.Models.Dto
{
    public class MascotasUpdateDto
    {
        [Required]
        public int MascotaId { get; set; }
        [Required]
        [MaxLength(30)]
        public string MascotaName { get; set; }

        public string MascotaDescription { get; set; }

        public DateTime Fecha { get; set; }
        [Required]

        public string RazaId { get; set; }
    }
}
