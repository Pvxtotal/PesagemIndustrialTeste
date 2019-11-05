﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pesagem_Industrial.Models
{
    public class Grupo
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}