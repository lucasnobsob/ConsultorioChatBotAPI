using ConsultorioChatBot.Business.Models;

namespace ConsultorioChatBot.Business.Interfaces.Repositories
{
    public interface IServicoRepository
    {
        Task<IEnumerable<Servico>> ObterListaServicos();
    }
}
