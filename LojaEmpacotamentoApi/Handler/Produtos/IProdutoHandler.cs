using LojaEmpacotamentoApi.Models.Produtos;
using LojaEmpacotamentoApi.Shared;

namespace LojaEmpacotamentoApi.Handler.Produtos
{
    public interface IProdutoHandler
    {
        Task<Output> SalvarProduto(SalvarProdutoModel produto);
    }
}
