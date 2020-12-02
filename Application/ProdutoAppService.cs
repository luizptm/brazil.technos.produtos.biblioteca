﻿using Controller;
using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppService
{

    public class ProdutoAppService : IProdutoAppService
    {
        IProdutoController controller;

        public ProdutoAppService(IProdutoController controller)
        {
        }

        public Produto Get(string codigo)
        {
            var result = this.controller.Get(codigo);
            return result;
        }

        public List<Produto> Find(Produto produto)
        {
            var result = this.controller.Find(produto);
            return result;
    }

        public Boolean Salvar(Produto produto)
        {
            var result = this.controller.Salvar(produto);
            return result;
        }

        public Boolean Excluir(Produto produto)
        {
            var result = this.controller.Salvar(produto);
            return result;
        }
    }

}
