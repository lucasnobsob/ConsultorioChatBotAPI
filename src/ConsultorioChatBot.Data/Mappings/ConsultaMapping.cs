using ConsultorioChatBot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultorioChatBot.Data.Mappings
{
    public class ConsultaMapping : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.NomePaciente)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(x => x.DataHora)
                .IsRequired()
                .HasColumnType("datetime");

            builder.ToTable(nameof(Consulta));
        }
    }
}
