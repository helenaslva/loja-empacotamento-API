using LojaEmpacotamentoApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaEmpacotamentoApi.Mappings
{
    public class PedidoCaixaMapping : IEntityTypeConfiguration<PedidoCaixa>
    {
        public void Configure(EntityTypeBuilder<PedidoCaixa> builder)
        {
            
            builder.ToTable("PedidoCaixa");

      
            builder.HasKey(pc => pc.Id);

      
            builder.HasOne(pc => pc.Pedido)
                .WithMany(p => p.Caixas)
                .HasForeignKey(pc => pc.PedidoId);

          
            builder.HasOne(pc => pc.Caixa)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(pc => pc.CaixaId);

  
            builder.HasMany(pc => pc.Produtos)
                .WithOne(cp => cp.PedidoCaixa)
                .HasForeignKey(cp => cp.PedidoCaixaId);
        }
    }
}
