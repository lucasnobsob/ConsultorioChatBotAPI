using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Repositories;
using ConsultorioChatBot.Business.Interfaces;
using System.Globalization;
using System.Text;

namespace ConsultorioChatBot.Business.Services.Intents
{
    public class AgendamentoHorarioIntent : BaseService, IIntentStrategy
    {
        private readonly IAgendaRepository _agendaRepository;
        public AgendamentoHorarioIntent(INotificador notificador,
            IAgendaRepository agendaRepository) : base(notificador)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task<IEnumerable<string>> ObterResposta<T>(T value)
        {
            var data = DateTime.Now;
            var result = new List<string>();
            var datas = await _agendaRepository.ObterListaDeDatasDisponíveis();
            var datesList = Enumerable.Range(0, 5).SelectMany(dayOffset => Enumerable.Range(8, 5)
                .Select(hour => DateTime.Today.AddDays(dayOffset).AddHours(hour))).ToList();
            var diasAgendados = datas.GroupBy(x => x).Select(g => g.Key).ToList();
            var horarios = datesList.Where(date => !diasAgendados.Contains(date) && date.Date == data.Date).ToList();

            //var data = (DateTime)Convert.ChangeType(value, typeof(DateTime));

            result.Add($"Agendamento em: {data.ToString("dd/MM/yyyy")}");
            result.Add("Por favor digite uma das opções de horário abaixo ou voltar:");
            foreach (var (horario, index) in horarios.Select((value, index) => (value, index)))
                result.Add($"{index + 1} - {horario.ToString("HH:mm")}\n");

            return result;
        }
    }
}
