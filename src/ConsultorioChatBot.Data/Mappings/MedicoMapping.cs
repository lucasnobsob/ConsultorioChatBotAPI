using ConsultorioChatBot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultorioChatBot.Data.Mappings
{
    public class MedicoMapping : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(x => x.Especialidade)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(x => x.CRM)
                .IsRequired()
                .HasColumnType("varchar(10)");
        }
    }
}
