using ConsultorioChatBot.Business.Interfaces;
using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Repositories;

namespace ConsultorioChatBot.Business.Services.Intents
{
    public class ConfirmacaoCancelamentoIntent : BaseService, IIntentStrategy
    {
        private readonly IAgendaRepository _agendaRepository;
        public ConfirmacaoCancelamentoIntent(INotificador notificador, 
            IAgendaRepository agendaRepository) : base(notificador)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task<IEnumerable<string>> ObterResposta<T>(T value)
        {
            var result = new List<string>();
            var agendamentos = await _agendaRepository.GetAll();
            var agdList = agendamentos.Select((value, index) => (value, index));

            if (value is string numero)
            {
                int.TryParse(numero, out var opcao);
                var agd = agdList.FirstOrDefault(x => (x.index + 1) == opcao);

                await _agendaRepository.Delete(agd.value.Id);
                result.Add("Agendamento cancelado!");
            }

            return result;
        }
    }
}
