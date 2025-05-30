using LojaEmpacotamentoApi.Handler.Pedidos;
using LojaEmpacotamentoApi.Models.Pedidos;
using LojaEmpacotamentoApi.Result.Pedidos;
using Microsoft.AspNetCore.Mvc;

namespace LojaEmpacotamentoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Produces("application/json")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoHandler _pedidoHandler;

        public PedidoController(IPedidoHandler pedidoHandler)
        {
            _pedidoHandler = pedidoHandler;
        }

        [HttpPost]
        public async Task<ActionResult<List<SalvarPedidoResult>>> ProcessarPedidos([FromBody] List<SalvarPedidoModel> pedidos)
        {
            try
            {
                var resultados = await _pedidoHandler.ProcessarPedidos(pedidos);
                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao processar pedidos: {ex.Message}");
            }
        }
    }
}
