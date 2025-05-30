using LojaEmpacotamentoApi.Handler.Caixas;
using LojaEmpacotamentoApi.Models.Caixa;
using LojaEmpacotamentoApi.Models.Produtos;
using LojaEmpacotamentoApi.Repository.Caixas;
using LojaEmpacotamentoApi.Result.Produtos;
using LojaEmpacotamentoApi.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LojaEmpacotamentoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        private readonly ICaixaRepository _caixaRepository;
        private readonly ICaixaHandler _caixaHandler;

        public CaixaController(ICaixaRepository caixaRepository, ICaixaHandler caixaHandler)
        {
            _caixaRepository = caixaRepository;
            _caixaHandler = caixaHandler;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListarCaixasResult>>> ListarCaixas()
        {
            try
            {
                var caixas = await _caixaRepository.ListarCaixas();
                return Ok(caixas);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Output>> CadastrarCaixa([FromBody] SalvarCaixaModel caixa)
        {
            var salvarCaixa = await _caixaHandler.SalvarCaixa(caixa);
            if (salvarCaixa.IsSuccess)
                return Ok(salvarCaixa);
            return BadRequest(salvarCaixa);
        }
  
    }
}
