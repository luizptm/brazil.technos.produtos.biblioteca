using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Marca")]
    public class Marca
    {
        [Required]
        public Int32? Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
