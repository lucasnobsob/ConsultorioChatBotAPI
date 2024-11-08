using ConsultorioChatBot.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioChatBot.Data.Context
{
    public class ConsultorioDbContext : DbContext
    {
        public ConsultorioDbContext(DbContextOptions<ConsultorioDbContext> options) : base(options) { }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Servico> Servicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConsultorioDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.Entity<Servico>().HasData(
                new Servico
                {
                    Id = Guid.NewGuid(),
                    Descricao = "# Consulta Ou Retorno  - Atendimento Presencial.",
                    TipoServico = TipoServico.Consulta
                },
                new Servico
                {
                    Id = Guid.NewGuid(),
                    Descricao = "Endoscopia Digestiva Alta E Depois digite 60.",
                    TipoServico = TipoServico.Exame
                },
                new Servico
                {
                    Id = Guid.NewGuid(),
                    Descricao = "Exame Colonoscopia nº 60 Para Preparo.",
                    TipoServico = TipoServico.Exame
                },
                new Servico
                {
                    Id = Guid.NewGuid(),
                    Descricao = "Virtual Atendimento Via Online.",
                    TipoServico = TipoServico.Consulta
                },
                new Servico
                {
                    Id = Guid.NewGuid(),
                    Descricao = "§ Endoscopia + Colonoscopia nº60 Preparo",
                    TipoServico = TipoServico.Exame
                });

            modelBuilder.Entity<Medico>().HasData(
                new Medico
                {
                    Id = Guid.NewGuid(),
                    Nome = "Alexandre Campos",
                    Especialidade = "Gastroenterologia",
                    CRM = "101196/SP"
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}