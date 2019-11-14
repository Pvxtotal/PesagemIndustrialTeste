using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Pesagem_Industrial.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Usuário")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [NotMapped]
        public string ConfirmaSenha { get; set; }

        public string Perfil { get; set; }

        [NotMapped]
        public Dictionary<int, string> Perfis { get; set; }

        public Usuario()
        {
            this.Perfis = new Dictionary<int, string>();
            Perfis.Add(1, "Operador");
            Perfis.Add(2, "Fornecedor");
            Perfis.Add(3, "Cliente");
            Perfis.Add(4, "Administrador");
        }



    }
}