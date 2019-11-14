using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pesagem_Industrial.Models
{
    [Table("Armazens")]
    public class Armazem
    {
       [Key]
        public int Id { get; set; }
        public string Local { get; set; }


    }
}