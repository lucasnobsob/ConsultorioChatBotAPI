using ConsultorioChatBot.Business.Interfaces;
using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Repositories;
using System.Globalization;

namespace ConsultorioChatBot.Business.Services.Intents
{
    public class AgendamentoDataIntent : BaseService, IIntentStrategy
    {
        private readonly IAgendaRepository _agendaRepository;
        public AgendamentoDataIntent(INotificador notificador,
            IAgendaRepository agendaRepository) : base(notificador)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task<IEnumerable<string>> ObterResposta<T>(T value)
        {
            var result = new List<string>();
            var datas = await _agendaRepository.ObterListaDeDatasDisponíveis();
            var diasSemana = Enumerable.Range(1, 5).Select(i => DateOnly.FromDateTime(DateTime.Now.AddDays(i - 1))).ToList();
            var diasAgendados = datas.GroupBy(x => x.Date).Select(x => DateOnly.FromDateTime(x.Key)).ToList();
            var diasDisponiveis = diasSemana.Except(diasAgendados).ToList();

            result.Add("Qual a data que deseja marcar?\r\n");
            result.Add("Digite em qual data deseja agendar, 6 para outras datas ou voltar: \n\n");

            foreach (var (data, index) in diasDisponiveis.Select((value, index) => (value, index)))
            {
                result.Add($"{index + 1} - {data.ToString("dddd", new CultureInfo("pt-BR"))}\n");
                result.Add($"{data.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("pt-BR"))}\n\n");
            }

            return result;
        }
    }
}
