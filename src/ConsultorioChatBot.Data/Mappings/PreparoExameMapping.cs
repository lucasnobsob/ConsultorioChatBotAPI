using ConsultorioChatBot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultorioChatBot.Data.Mappings
{
    public class PreparoExameMapping : IEntityTypeConfiguration<PreparoExame>
    {
        public void Configure(EntityTypeBuilder<PreparoExame> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Texto)
                .IsRequired()
                .HasColumnType("text");

            builder.ToTable(nameof(PreparoExame));
        }
    }
}
