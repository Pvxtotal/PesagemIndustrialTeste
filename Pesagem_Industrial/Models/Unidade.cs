using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pesagem_Industrial.Models
{
    [Table("Unidades")]
    public class Unidade
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Medida { get; set; }
        [Required]
        public string Tipo { get; set; }

        [NotMapped]
        public List<string> Tipos { get; set; }


        public Unidade()
        {
            this.Tipos = new List<string>();
        }
    
  
    }
}