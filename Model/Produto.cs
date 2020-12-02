using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("Produto")]
    public class Produto
    {
        [Required]
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }

        public double Preco { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        public DateTime DataLancamento { get; set; }
        public TipoProduto TipoProduto { get; set; }
    }
}
