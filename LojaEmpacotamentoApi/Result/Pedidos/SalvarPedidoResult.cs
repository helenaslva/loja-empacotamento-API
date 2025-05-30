using LojaEmpacotamentoApi.Result.Caixas;

namespace LojaEmpacotamentoApi.Result.Pedidos
{
    public class SalvarPedidoResult
    {
        public Guid PedidoId { get; set; }
        public List<CaixaUsadaResult> CaixasUsadas { get; set; }
    }

}
