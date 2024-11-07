
using ConsultorioChatBot.Business.Models;

namespace ConsultorioChatBot.Business.Interfaces.Repositories
{
    public interface IAgendaRepository
    {
        Task<IEnumerable<DateTime>> ObterListaDeDatasDisponíveis();
        Task<IEnumerable<Agenda>> ObterTodosOsAgendamentos();
    }
}
