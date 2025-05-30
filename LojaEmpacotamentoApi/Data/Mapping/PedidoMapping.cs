using LojaEmpacotamentoApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaEmpacotamentoApi.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
         
            builder.ToTable("Pedido");

          
            builder.HasKey(p => p.Id);

          
            builder.Property(p => p.DataPedido)
                .IsRequired();

            builder.Property(p => p.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(p => p.Produtos)
                .WithOne(pp => pp.Pedido)
                .HasForeignKey(pp => pp.PedidoId);

            builder.HasMany(p => p.Caixas)
                .WithOne(pc => pc.Pedido)
                .HasForeignKey(pc => pc.PedidoId);
        }
    }
}
