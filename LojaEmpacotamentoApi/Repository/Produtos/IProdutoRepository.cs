using LojaEmpacotamentoApi.Result.Produtos;

namespace LojaEmpacotamentoApi.Repository.Produto
{
    public interface IProdutoRepository
    {
        Task<Guid> SalvarProduto(Entities.Produto produto);
        Task<List<ListarCaixasResult>> ListarProdutos();
    }
}
