using LojaEmpacotamentoApi.Entities;
using LojaEmpacotamentoApi.Result.Pedidos;

namespace LojaEmpacotamentoApi.Repository.Pedidos
{
    public interface IPedidoRepository
    {
        Task SalvarPedido(Pedido pedido, List<PedidoProduto> produtos, List<PedidoCaixa> caixas);
        Task<List<ListarPedidosResult>> ListarPedidos();
    }
}
