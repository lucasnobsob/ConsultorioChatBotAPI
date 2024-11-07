using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Services;
using ConsultorioChatBot.Business.Models.Validations;

namespace ConsultorioChatBot.Business.Services
{
    public class AgendaService : IAgendaService, IIntentStrategy
    {
        public Task<IEnumerable<string>> ObterResposta<T>(T value)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DateTime>> VerificarDatasDisponiveis()
        {

            return new List<DateTime>();
        }
    }
}
