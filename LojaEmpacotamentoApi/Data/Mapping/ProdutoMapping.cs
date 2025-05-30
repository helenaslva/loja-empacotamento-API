namespace LojaEmpacotamentoApi.Data.Mapping
{
    using LojaEmpacotamentoApi.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.AlturaCm).IsRequired();
            builder.Property(p => p.LarguraCm).IsRequired();
            builder.Property(p => p.ComprimentoCm).IsRequired();
            builder.Property(p => p.PesoKg).IsRequired();

            builder.HasMany(p => p.Pedidos)
                .WithOne(pp => pp.Produto)
                .HasForeignKey(pp => pp.ProdutoId);

            builder.HasMany(p => p.CaixaProdutos)
                .WithOne(cp => cp.Produto)
                .HasForeignKey(cp => cp.ProdutoId);
        }
    }

}
