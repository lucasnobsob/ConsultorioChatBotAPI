using ConsultorioChatBot.Business.Interfaces;
using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Repositories;
using System.Text;

namespace ConsultorioChatBot.Business.Services.Intents
{
    public class CancelarAgendamentoIntent : BaseService, IIntentStrategy
    {
        private readonly IAgendaRepository _agendaRepository;
        public CancelarAgendamentoIntent(INotificador notificador, 
            IAgendaRepository agendaRepository) : base(notificador)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task<IEnumerable<string>> ObterResposta<T>(T value)
        {
            var result = new List<string>();
            var agendamentos = await _agendaRepository.ObterAgendaComMedicoEServico();
            if (agendamentos is null || !agendamentos.Any())
                return new List<string>() { "Nehum agendamento disponível para cancelamento." };

            result.Add("Qual agendamento você quer cancelar?");
            foreach (var (agenda, index) in agendamentos.Select((value, index) => (value, index)))
            {
                var dataHora = agenda.DataHora.ToString("dddd, dd/MM - HH:mm 'h'");
                result.Add($"{index + 1} - {dataHora}");
                result.Add($"{agenda.Servico.Descricao} com o Dr.{agenda.Medico.Nome}");
            }

            return result;
        }
    }
}
