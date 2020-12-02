using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Produto
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataLancamento { get; set; }
        public TipoProduto TipoProduto { get; set; }
    }
}
