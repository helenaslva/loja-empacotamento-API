using LojaEmpacotamentoApi.Data;
using LojaEmpacotamentoApi.Entities;
using LojaEmpacotamentoApi.Result.Pedidos;
using Microsoft.EntityFrameworkCore;

namespace LojaEmpacotamentoApi.Repository.Pedidos
{
    public class PedidoRepository : IPedidoRepository
    {

        private readonly Context _context;
        private readonly DbSet<Pedido> _pedido;

        public PedidoRepository(Context context)
        {
            _context = context;
            _pedido = _context.Set<Pedido>();
        }

        public Task<List<ListarPedidosResult>> ListarPedidos()
        {
            return _pedido
                .Select(x => new ListarPedidosResult()
                {
                    Id = x.Id,
                    DataPedido = x.DataPedido,
                    Status = x.Status,
                }).ToListAsync();
        }
        public async Task SalvarPedido(Pedido pedido, List<PedidoProduto> produtos, List<PedidoCaixa> caixas)
        {
           
            await _context.Pedidos.AddAsync(pedido);

       
            await _context.PedidoProdutos.AddRangeAsync(produtos);

            await _context.PedidoCaixas.AddRangeAsync(caixas);

            await _context.SaveChangesAsync();
        }
    }
}
