using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("TipoProduto")]
    public class TipoProduto
    {
        [Required]
        public Int32? Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
