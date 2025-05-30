using LojaEmpacotamentoApi.Data.Mapping;
using LojaEmpacotamentoApi.Entities;
using LojaEmpacotamentoApi.Mappings;
using Microsoft.EntityFrameworkCore;

namespace LojaEmpacotamentoApi.Data
{
    public class Context : DbContext
    {
     public Context(DbContextOptions<Context> opts)
    : base(opts)
     {

     }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }
        public DbSet<PedidoCaixa> PedidoCaixas { get; set; }
        public DbSet<CaixaProduto> CaixaProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            modelBuilder.ApplyConfiguration(new PedidoMapping());
            modelBuilder.ApplyConfiguration(new PedidoMapping());
            modelBuilder.ApplyConfiguration(new PedidoCaixaMapping());
            modelBuilder.ApplyConfiguration(new PedidoProdutoMapping());
            modelBuilder.ApplyConfiguration(new CaixaProdutoMapping());
            modelBuilder.ApplyConfiguration(new CaixaMapping());

        }
    }
}
