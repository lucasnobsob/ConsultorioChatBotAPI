using ConsultorioChatBot.Business.Interfaces.Repositories;
using ConsultorioChatBot.Business.Models;
using ConsultorioChatBot.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioChatBot.Data.Repository
{
    public class MedicoRepository : Repository<Medico>, IMedicoRepository
    {
        public MedicoRepository(ConsultorioDbContext db) : base(db) { }

        public async Task<IEnumerable<Servico>> GetMedicoServicosAsync(int numero)
        {
            return await Db.Servicos.Include(x => x.Medicos).Where(x => x.Medicos.Any(y => y.Numero == numero)).ToListAsync();
        }
    }
}
