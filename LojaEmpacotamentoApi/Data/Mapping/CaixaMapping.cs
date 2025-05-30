using LojaEmpacotamentoApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaEmpacotamentoApi.Mappings
{
    public class CaixaMapping : IEntityTypeConfiguration<Caixa>
    {
        public void Configure(EntityTypeBuilder<Caixa> builder)
        {
            
            builder.ToTable("Caixa");

            
            builder.HasKey(c => c.Id);

           
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.AlturaCm)
                .IsRequired();

            builder.Property(c => c.LarguraCm)
                .IsRequired();

            builder.Property(c => c.ComprimentoCm)
                .IsRequired();

            builder.Property(c => c.PesoMaxKg)
                .IsRequired();

       
            builder.Ignore(c => c.VolumeCm3);

     
            builder.HasMany(c => c.Pedidos)
                .WithOne(pc => pc.Caixa)
                .HasForeignKey(pc => pc.CaixaId);
        }
    }
}
