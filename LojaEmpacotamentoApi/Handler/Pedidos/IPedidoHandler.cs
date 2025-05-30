using LojaEmpacotamentoApi.Models.Pedidos;
using LojaEmpacotamentoApi.Result.Pedidos;

namespace LojaEmpacotamentoApi.Handler.Pedidos
{
    public interface IPedidoHandler
    {
       Task<List<SalvarPedidoResult>> ProcessarPedidos(List <SalvarPedidoModel> pedidosModel);
            
    }
}
