using ConsultorioChatBot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultorioChatBot.Data.Mappings
{
    public class ExameMapping : IEntityTypeConfiguration<Exame>
    {
        public void Configure(EntityTypeBuilder<Exame> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.DuracaoHoras)
                .IsRequired();

            builder.ToTable(nameof(Exame));
        }
    }
}
