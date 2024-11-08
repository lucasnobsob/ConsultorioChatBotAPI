using ConsultorioChatBot.Business.Helpers;
using ConsultorioChatBot.Business.Interfaces;
using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Repositories;
using ConsultorioChatBot.Business.Interfaces.Services;
using ConsultorioChatBot.Business.Models;

namespace ConsultorioChatBot.Business.Services.Intents
{
    public class FinalizacaoAgendamentoIntent : BaseService, IIntentStrategy
    {
        private readonly IRedisCacheService _redisCacheService;
        private readonly IAgendaRepository _agendaRepository;

        public FinalizacaoAgendamentoIntent(INotificador notificador, 
            IRedisCacheService redisCacheService, 
            IAgendaRepository agendaRepository) : base(notificador)
        {
            _redisCacheService = redisCacheService;
            _agendaRepository = agendaRepository;
        }

        public async Task<IEnumerable<string>> ObterResposta<T>(T value)
        {
            var result = new List<string>();
            var agenda = new Agenda();
            agenda.Contato = "(18)99718-4750";
            var medico = await _redisCacheService.GetCacheValueAsync<Medico>("medico");
            var servico = await _redisCacheService.GetCacheValueAsync<Servico>("servico");
            var horario = await _redisCacheService.GetCacheValueAsync<DateTime>("horario");

            if (value is string confirmacao)
            {
                int.TryParse(confirmacao, out var confirmado);
                agenda.MedicoId = medico.Id;
                agenda.ServicoId = servico.Id;
                agenda.DataHora = horario;

                if (confirmado == 1)
                {
                    await _agendaRepository.Add(agenda);
                    result.Add("Obrigado");
                    result.Add("Lembraremos você por mensagem quando a data estiver próxima");
                }
                else
                {
                    result.Add("Por favor, revise o agendamento");
                }
            }

            return result;
        }
    }
}
