using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPratica.Models
{
    public class Mascotas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int MascotaId { get; set; }
        [Required]
        public string MascotaName { get; set; }

        public string MascotaDescription { get; set; }

        public DateTime Fecha { get; set; }

        public int RazaId { get; set; }
        [ForeignKey("RazaId")]

        public Raza Raza { get; set; }


    }
}
