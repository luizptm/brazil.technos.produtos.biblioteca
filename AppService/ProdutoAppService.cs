﻿using Controller;
using Model;
using System;
using System.Collections.Generic;

namespace AppService
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoController controller;

        public ProdutoAppService(IProdutoController controller)
        {
            this.controller = controller;
        }

        public Produto Get(Int32 codigo)
        {
            var result = this.controller.Get(codigo);
            return result;
        }

        public List<Produto> GetAll()
        {
            var result = this.controller.GetAll();
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

        public Boolean Excluir(Int32 codigo)
        {
            var result = this.controller.Excluir(codigo);
            return result;
        }

        public Boolean Excluir(Produto produto)
        {
            var result = this.controller.Excluir(produto);
            return result;
        }
    }

}
