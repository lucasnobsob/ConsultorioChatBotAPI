using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Repositories;
using ConsultorioChatBot.Business.Interfaces;
using System.Globalization;
using System.Text;
using ConsultorioChatBot.Business.Helpers;
using ConsultorioChatBot.Business.Interfaces.Services;

namespace ConsultorioChatBot.Business.Services.Intents
{
    public class AgendamentoHorarioIntent : BaseService, IIntentStrategy
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IRedisCacheService _redisCacheService;
        public AgendamentoHorarioIntent(INotificador notificador,
            IAgendaRepository agendaRepository,
            IRedisCacheService redisCacheService) : base(notificador)
        {
            _agendaRepository = agendaRepository;
            _redisCacheService = redisCacheService;
        }

        public async Task<IEnumerable<string>> ObterResposta<T>(T value)
        {
            var data = DateOnly.FromDateTime(DateTime.Now);
            var result = new List<string>();
            var datas = await _agendaRepository.ObterListaDeDatasDisponíveis();
            IEnumerable<(int, DateTime)>? horarios = null;

            if (value is string numero)
            {
                int.TryParse(numero, out var dataIndex);
                var diasSemana = DateHelper.GetDaysOfWeek();
                var dia = diasSemana.FirstOrDefault(x => x.Item1 == dataIndex);
                data = dia.Item2;
                horarios = DateHelper.GetHoursOfDay(datas, data);
                await _redisCacheService.SetCacheValueAsync("data", data, TimeSpan.FromMinutes(30));
            }

            if (horarios is null)
                return new List<string>();

            result.Add($"Agendamento em: {data.ToString("dd/MM/yyyy")}");
            result.Add("Por favor digite uma das opções de horário abaixo ou voltar:");
            foreach (var horario in horarios)
                result.Add($"{horario.Item1} - {horario.Item2.ToString("HH:mm")}");

            return result;
        }
    }
}
