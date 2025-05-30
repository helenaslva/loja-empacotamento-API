using LojaEmpacotamentoApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaEmpacotamentoApi.Mappings
{
    public class CaixaProdutoMapping : IEntityTypeConfiguration<CaixaProduto>
    {
        public void Configure(EntityTypeBuilder<CaixaProduto> builder)
        {
           
            builder.ToTable("CaixaProduto");

         
            builder.HasKey(cp => cp.Id);

       
            builder.Property(cp => cp.Quantidade)
                .IsRequired();

      
            builder.HasOne(cp => cp.PedidoCaixa)
                .WithMany(pc => pc.Produtos)
                .HasForeignKey(cp => cp.PedidoCaixaId);

            builder.HasOne(cp => cp.Produto)
                .WithMany(p => p.CaixaProdutos)
                .HasForeignKey(cp => cp.ProdutoId);
        }
    }
}
