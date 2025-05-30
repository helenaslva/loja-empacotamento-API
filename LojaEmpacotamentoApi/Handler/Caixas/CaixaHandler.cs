using LojaEmpacotamentoApi.Entities;
using LojaEmpacotamentoApi.Models.Caixa;
using LojaEmpacotamentoApi.Repository.Caixas;
using LojaEmpacotamentoApi.Shared;
using System.Drawing.Printing;

namespace LojaEmpacotamentoApi.Handler.Caixas
{
    public class CaixaHandler : ICaixaHandler
    {
        private ICaixaRepository _caixaRepository;

        public CaixaHandler(ICaixaRepository caixaRepository)
        {
            _caixaRepository = caixaRepository;
        }

        public async Task<Output> SalvarCaixa(SalvarCaixaModel caixa)
        {
            if (caixa != null)
            {
                var caixaOfc = new Caixa() { 
                    AlturaCm = caixa.AlturaCm,
                    LarguraCm = caixa.LarguraCm,
                    Id = caixa.Id,
                    PesoMaxKg  =  caixa.PesoMaxKg
                };

                var caixaSalva = _caixaRepository.SalvarCaixa(caixaOfc);

                if (caixaSalva != null)
                {
                    return new Output() { IsSuccess = true, Message = "Caixa salva com sucesso" };
                }

                return new Output() { IsSuccess = false, Message = "Algum erro aconteceu ao salvar" };

            }
            else
            {
                return new Output { IsSuccess = false, Message = "Caixa não deve ser nula" };
            }
        }
    }
}
