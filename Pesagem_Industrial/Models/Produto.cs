using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pesagem_Industrial.Models
{
    [Table("Produtos")]
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

        public int? Armazem_Id { get; set; }

        [ForeignKey("Armazem_Id")]
        public virtual Armazem Armazem { get; set; }

        public int? Unidade_Id { get; set; }

        [ForeignKey("Unidade_Id")]
        public virtual Unidade Unidade { get; set; }

        public int? Grupo_Id { get; set; }
        [ForeignKey("Grupo_Id")]
        public virtual Grupo Grupo { get; set; }

   


      


       
    }
}