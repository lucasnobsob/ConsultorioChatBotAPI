using ConsultorioChatBot.Business.Models;

namespace ConsultorioChatBot.Business.Interfaces.Repositories
{
    public interface IMedicoRepository : IRepository<Medico>
    {
        Task<IEnumerable<Servico>> GetMedicoServicosAsync(int numero);
    }
}
