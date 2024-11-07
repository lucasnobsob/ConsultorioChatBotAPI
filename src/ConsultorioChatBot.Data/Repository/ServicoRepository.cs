using ConsultorioChatBot.Business.Interfaces.Repositories;
using ConsultorioChatBot.Business.Models;
using ConsultorioChatBot.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioChatBot.Data.Repository
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(ConsultorioDbContext db) : base(db) { }

        public async Task<IEnumerable<Servico>> ObterListaServicos()
        {
            return await Db.Servicos.AsNoTracking().ToListAsync();
        }
    }
}
