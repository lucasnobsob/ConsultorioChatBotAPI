
using ConsultorioChatBot.Business.Models;

namespace ConsultorioChatBot.Business.Interfaces.Repositories
{
    public interface IAgendaRepository : IRepository<Agenda>
    {
        Task<IEnumerable<Agenda>> ObterAgendaComMedicoEServico();
        Task<IEnumerable<DateTime>> ObterListaDeDatasDisponíveis();
    }
}
