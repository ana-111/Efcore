using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Efcore.Domains;
using Efcore.Interfaces;
using Efcore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Efcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public List<Produto> Get()
        {
            return _produtoRepository.Listar();
        }

        [HttpGet("{id}")]
        public Produto Get(Guid id)
        {
            return _produtoRepository.BuscarPorId(id);
        }

        [HttpGet]
        public void Post(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
        }

        [HttpGet("{id}")]
        public void Put(Guid id, Produto produto)
        {
            produto.Id = id;
            _produtoRepository.Editar(produto);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _produtoRepository.Remover(id);
        }


    }

}
