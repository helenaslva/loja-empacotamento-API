using LojaEmpacotamentoApi.Models.Caixa;
using LojaEmpacotamentoApi.Shared;

namespace LojaEmpacotamentoApi.Handler.Caixas
{
    public interface ICaixaHandler
    {
        Task<Output> SalvarCaixa(SalvarCaixaModel caixa);
    }
}
