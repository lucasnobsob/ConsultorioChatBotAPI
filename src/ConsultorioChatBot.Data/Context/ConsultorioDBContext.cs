using ConsultorioChatBot.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioChatBot.Data.Context
{
    public class ConsultorioDbContext : DbContext
    {
        public ConsultorioDbContext(DbContextOptions<ConsultorioDbContext> options) : base(options) { }

        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<PreparoExame> PreparoExames { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    foreach (var property in modelBuilder.Model.GetEntityTypes()
        //        .SelectMany(e => e.GetProperties()
        //            .Where(p => p.ClrType == typeof(string))))
        //        property.SetColumnType("varchar(100)");

        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConsultorioDbContext).Assembly);

        //    foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        //    base.OnModelCreating(modelBuilder);
        //}

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("DataCadastro").CurrentValue = DateTime.Now;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property("DataCadastro").IsModified = false;
        //        }
        //    }

        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}