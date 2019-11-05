using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pesagem_Industrial.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Descricao { get; set; }
        [Required]
        [MaxLength(200)]
        public string Origem { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [NotMapped]
        public Unidade Unidade { get; set; }
       // [ForeignKey("Id")]
        //public Grupo Grupo { get; set; }
        //[ForeignKey("Id")]
       // public Armazem Armazem { get; set; }


       
    }
}