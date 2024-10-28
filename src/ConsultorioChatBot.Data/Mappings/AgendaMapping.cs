using ConsultorioChatBot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultorioChatBot.Data.Mappings
{
    public class AgendaMapping : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Contato)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(x => x.DataHora)
                .IsRequired();

            builder.Property(x => x.Confirmacao)
                .IsRequired();

            builder.ToTable(nameof(Agenda));
        }
    }
}
