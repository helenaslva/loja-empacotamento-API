using LojaEmpacotamentoApi.Handler.Produtos;
using LojaEmpacotamentoApi.Models.Produtos;
using LojaEmpacotamentoApi.Repository.Produto;
using LojaEmpacotamentoApi.Result.Produtos;
using LojaEmpacotamentoApi.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LojaEmpacotamentoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Produces("application/json")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoHandler _produtoHandler;

        public ProdutoController(IProdutoRepository produtoRepository, IProdutoHandler handler)
        {
            _produtoRepository = produtoRepository;
            _produtoHandler = handler;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListarCaixasResult>>>ListarProdutos()
        {
            try
            {
                var produtos = await _produtoRepository.ListarProdutos();
                return Ok(produtos);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

  

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<ActionResult<Output>>CadastrarProduto([FromBody] SalvarProdutoModel produto)
        {
            var salvarProduto = await _produtoHandler.SalvarProduto(produto);
            if(salvarProduto.IsSuccess)
                return Ok(salvarProduto);
            return BadRequest(salvarProduto);
        }

        
    }
}
