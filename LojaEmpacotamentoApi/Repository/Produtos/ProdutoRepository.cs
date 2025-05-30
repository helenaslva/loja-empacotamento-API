using LojaEmpacotamentoApi.Data;
using LojaEmpacotamentoApi.Entities;
using LojaEmpacotamentoApi.Repository.Produto;
using LojaEmpacotamentoApi.Result.Produtos;
using Microsoft.EntityFrameworkCore;

namespace LojaEmpacotamentoApi.Repository.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Context _context;
        private readonly DbSet<Entities.Produto> _produto;

        public ProdutoRepository(Context context)
        {
            _context = context;
            _produto = _context.Set<Entities.Produto>();
        }

        public Task<List<ListarCaixasResult>> ListarProdutos()
        {
            return _produto
                .Select(x => new ListarCaixasResult
                {
                    Id = x.Id,
                    AlturaCm = x.AlturaCm,
                    LarguraCm = x.LarguraCm,
                    ComprimentoCm = x.ComprimentoCm,
                    PesoKg = x.PesoKg,
                    Nome = x.Nome
                }).ToListAsync();
        }

        public async Task<Guid> SalvarProduto(Entities.Produto produto)
        {
            var salvo = _produto.Add(produto);
            await _context.SaveChangesAsync();
            return produto.Id;
        }
    }
}
