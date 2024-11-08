using ConsultorioChatBot.Business.Models;

namespace ConsultorioChatBot.Business.Interfaces.Repositories
{
    public interface IServicoRepository : IRepository<Servico>
    {
        Task<IEnumerable<Servico>> ObterListaServicos();
    }
}
