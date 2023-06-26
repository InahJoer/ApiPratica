﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPratica.Models
{
    public class Raza
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]

        public string RazaName { get; set; }
        [Required]

        public string RazaColor {  get; set; }

    }
}
