using LojaEmpacotamentoApi.Entities;
using LojaEmpacotamentoApi.Result.Caixas;

namespace LojaEmpacotamentoApi.Repository.Caixas
{
    public interface ICaixaRepository
    {
        Task<Guid> SalvarCaixa(Caixa caixa);
        Task<List<ListarCaixaResult>> ListarCaixas();
    }
}
