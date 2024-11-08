using ConsultorioChatBot.Business.Interfaces.Repositories;
using ConsultorioChatBot.Business.Models;
using ConsultorioChatBot.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioChatBot.Data.Repository
{
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(ConsultorioDbContext db) : base(db) { }

        public async Task<IEnumerable<DateTime>> ObterListaDeDatasDisponíveis()
        {
            return await Db.Agendas.AsNoTracking()
                .Where(x => x.DataHora.Date >= DateTime.Now.Date && 
                       x.DataHora <= DateTime.Now.Date.AddDays(5))
                .Select(x => x.DataHora.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Agenda>> ObterAgendaComMedicoEServico()
        {
            return await Db.Agendas.AsNoTracking().Include(x => x.Medico).Include(x => x.Servico).ToListAsync();
        }

    }
}
