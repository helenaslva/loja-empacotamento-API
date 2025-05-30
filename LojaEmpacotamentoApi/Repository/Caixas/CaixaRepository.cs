using LojaEmpacotamentoApi.Data;
using LojaEmpacotamentoApi.Entities;
using LojaEmpacotamentoApi.Result.Caixas;
using Microsoft.EntityFrameworkCore;

namespace LojaEmpacotamentoApi.Repository.Caixas
{
    public class CaixaRepository : ICaixaRepository
    {
        private readonly Context _context;
        private readonly DbSet<Caixa> _caixa;

        public CaixaRepository(Context context)
        {
            _context = context;
            _caixa = _context.Set<Caixa>();
        }

        public Task<List<ListarCaixaResult>> ListarCaixas()
        {
            var caixas = _caixa.Select(x => new ListarCaixaResult
            {
                Id = x.Id,
                AlturaCm = x.AlturaCm,
                LarguraCm = x.LarguraCm,
                ComprimentoCm = x.ComprimentoCm,
                PesoMaxKg = x.PesoMaxKg,

            }).ToListAsync();

            return caixas;

            
        }

        public async Task<Guid> SalvarCaixa(Caixa caixa)
        {
            var caixaSalva = _caixa.Add(caixa);
            await _context.SaveChangesAsync();
            return caixa.Id;
        }
    }
}
