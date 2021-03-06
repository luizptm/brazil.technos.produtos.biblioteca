using Controller;
using Data.Repository;
using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Test
{
    public class ProdutoUnitTest
    {
        IProdutoRepository data;
        IProdutoController controller;

        [SetUp]
        public void Setup(ProdutoRepository data, ProdutoController controller)
        {
            this.data = data;
            this.controller = controller;
        }

        [Test]
        public void GetNullTest()
        {
            Int32 codigo = 1;
            Produto result = this.controller.Get(codigo);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void FindNoneTest()
        {
            Produto p = new Produto();
            List <Produto> expectedList = new List<Produto>();
            List<Produto> returnedList = this.controller.Find(p);
            Assert.AreEqual(expectedList.Count, returnedList.Count);
        }

        [Test]
        public void SaveOneProductTest()
        {
            Produto p = new Produto();
            p.Codigo = 1;
            Boolean salvar = this.controller.Salvar(p);
            Produto result = this.controller.Get(p.Codigo.Value);
            Assert.AreEqual(p.Codigo, result.Codigo);
        }

        public void UpdateOneProductDescriptionTest()
        {
            Produto p = new Produto();
            p.Codigo = 1;
            p.Descricao = "Produto 0001";
            Boolean salvar = this.controller.Salvar(p);
            Produto result = this.controller.Get(p.Codigo.Value);
            Assert.AreEqual(p.Codigo, result.Codigo);
            Assert.AreEqual(p.Descricao, result.Descricao);
        }

        public void UpdateOneProductAllDataTest()
        {
            TipoProduto tp = new TipoProduto();
            tp.Id = 1;
            tp.Nome = "Nome 1";
            //Boolean salvar = this.tipoProdutocontroller.Salvar(tp);

            Produto p = new Produto();
            p.Codigo = 1;
            p.Descricao = "Produto 0001";
            p.Marca = new Marca();
            p.Preco = 1000;
            p.DataCadastro = new DateTime();
            p.DataLancamento = new DateTime();
            p.TipoProduto = tp;
            
            Boolean salvar = this.controller.Salvar(p);
            Produto result = this.controller.Get(p.Codigo.Value);
            Assert.AreEqual(p.Codigo, result.Codigo);
            Assert.AreEqual(p.Descricao, result.Descricao);
        }

        public void DeleteOneProductTest()
        {
            Produto p = new Produto();
            p.Codigo = 1;
            bool excluir = this.controller.Excluir(p);
            Produto result = this.controller.Get(p.Codigo.Value);
            Assert.AreEqual(null, result);
        }
    }
}