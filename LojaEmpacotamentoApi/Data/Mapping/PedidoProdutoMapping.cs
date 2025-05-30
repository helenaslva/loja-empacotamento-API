
using LojaEmpacotamentoApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaEmpacotamentoApi.Mappings
{
    public class PedidoProdutoMapping : IEntityTypeConfiguration<PedidoProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {
           
            builder.ToTable("PedidoProduto");

       
            builder.HasKey(pp => pp.Id);

          
            builder.Property(pp => pp.Quantidade)
                .IsRequired();

         
            builder.HasOne(pp => pp.Pedido)
                .WithMany(p => p.Produtos)
                .HasForeignKey(pp => pp.PedidoId);

        
            builder.HasOne(pp => pp.Produto)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(pp => pp.ProdutoId);
        }
    }
}
