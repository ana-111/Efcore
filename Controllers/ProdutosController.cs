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
        public IActionResult Get()
        {
            try
            {
                //Listar os produtos no repositorio
                var produtos = _produtoRepository.Listar();

                //Verificar se existe produtos, se não existir ira retornar Sem Conteudo
                if (produtos.Count == 0)
                    return NoContent();

                //Se existir retornara ok
                return Ok(produtos);
            }
            catch(Exception ex)
            {
                //Se dar algum erro retornara BadRequest e uma mensagem de erro
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //buscar produto no repositorio
                Produto produto = _produtoRepository.BuscarPorId(id);

                //verificar se o produto existe, caso não exista retornar com NotFund
                if (produto == null)
                    return NotFound();

                //caso o produto exista retornara ok junto com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //se ocorrer algum erro retornara Badrequest com a mensagem de erro 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Post(Produto produto)
        {
            try
            {
                //add um produto
                _produtoRepository.Adicionar(produto);

                //retornar ok com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                var produtoTemp = _produtoRepository.BuscarPorId(id);

                if (produtoTemp == null)
                    return NotFound();

                produto.Id = id;
                _produtoRepository.Editar(produto);

                return Ok(produto);
            }

            catch (Exception ex)
            {
                //se ocorrer algum erro retornara Badrequest com a mensagem de erro 
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                _produtoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                //se ocorrer algum erro retornara Badrequest com a mensagem de erro 
                return BadRequest(ex.Message);
            }
        }


    }

}
