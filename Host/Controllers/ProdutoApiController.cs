using AppService;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoApiController : ControllerBase
    {
        protected readonly IProdutoAppService service;

        public ProdutoApiController(IProdutoAppService service)
        {
            this.service = service;
        }

        [HttpGet]
        public Produto Get(Int32 codigo)
        {
            var result = this.service.Get(codigo);
            return result;
        }

        [HttpGet]
        public List<Produto> GetAll()
        {
            var result = this.service.GetAll();
            return result;
        }

        [HttpPost]
        public List<Produto> Find(Produto produto)
        {
            var result = this.service.Find(produto);
            return result;
        }

        [HttpPost]
        public Boolean Salvar(Produto produto)
        {
            var result = this.service.Salvar(produto);
            return result;
        }

        [HttpDelete]
        public Boolean Excluir(Int32 codigo)
        {
            var result = this.service.Excluir(codigo);
            return result;
        }

        [HttpDelete]
        public Boolean Excluir(Produto produto)
        {
            var result = this.service.Excluir(produto);
            return result;
        }
    }
}
