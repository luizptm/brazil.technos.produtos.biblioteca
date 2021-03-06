﻿using AppService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace Host.Controllers
{
    /// <summary>
    /// ProdutoController
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class ProdutoController : ControllerBase
    {
        /// <summary>
        /// service
        /// </summary>
        protected readonly IProdutoAppService service;

        /// <summary>
        /// Construtor
        /// </summary>
        public ProdutoController(IProdutoAppService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Obtém Por ID
        /// </summary>
        /// <param name="codigo">código</param>
        /// <returns>Produto</returns>
        [HttpGet]
        [ResponseType(typeof(Produto))]
        public Produto Get(Int32 codigo)
        {
            var result = this.service.Get(codigo);
            return result;
        }

        /// <summary>
        /// Obtém Todos
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        [HttpPost, ActionName("All")]
        [ResponseType(typeof(List<Produto>))]
        public List<Produto> GetAll()
        {
            var result = this.service.GetAll();
            return result;
        }

        /// <summary>
        /// Busca
        /// </summary>
        /// <param name="produto">produto</param>
        /// <returns>Lista de Produtos</returns>
        [HttpPost, ActionName("Find")]
        [ResponseType(typeof(List<Produto>))]
        public List<Produto> Find(Produto produto)
        {
            var result = this.service.Find(produto);
            return result;
        }

        /// <summary>
        /// Salva um Produto (cria ou atualiza)
        /// </summary>
        /// <param name="produto">produto</param>
        /// <returns>Booleano</returns>
        [HttpPost, ActionName("Save")]
        [ValidateAntiForgeryToken]
        public Boolean Salvar(Produto produto)
        {
            var result = this.service.Salvar(produto);
            return result;
        }

        /// <summary>
        /// Exclui um Produto
        /// </summary>
        /// <param name="codigo">código</param>
        /// <returns>Booleano</returns>
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public Boolean Excluir(Int32 codigo)
        {
            var result = this.service.Excluir(codigo);
            return result;
        }

        /// <summary>
        /// Exclui um Produto
        /// </summary>
        /// <param name="produto">produto</param>
        /// <returns>Booleano</returns>
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public Boolean Excluir(Produto produto)
        {
            var result = this.service.Excluir(produto);
            return result;
        }
    }
}
