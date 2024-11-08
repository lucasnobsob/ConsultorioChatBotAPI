using ConsultorioChatBot.Business.Helpers;
using ConsultorioChatBot.Business.Interfaces;
using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Services;
using ConsultorioChatBot.Business.Models;

namespace ConsultorioChatBot.Business.Services.Intents
{
    public class ConfirmacaoAgendamentoIntent : BaseService, IIntentStrategy
    {
        private readonly IRedisCacheService _redisCacheService;

        public ConfirmacaoAgendamentoIntent(INotificador notificador,
            IRedisCacheService redisCacheService) : base(notificador)
        {
            _redisCacheService = redisCacheService;
        }

        public async Task<IEnumerable<string>> ObterResposta<T>(T value)
        {
            var result = new List<string>();

            var agenda = new Agenda();
            var medico = await _redisCacheService.GetCacheValueAsync<Medico>("medico");
            var servico = await _redisCacheService.GetCacheValueAsync<Servico>("servico");
            var data = await _redisCacheService.GetCacheValueAsync<DateOnly>("data");

            if (value is string horaIndex)
            {
                int.TryParse(horaIndex, out var horaNumero);
                var horarios = DateHelper.GetHoursOfDay(new List<DateTime>(), data);
                var horario = horarios.FirstOrDefault(x => x.Item1 == horaNumero).Item2;
                await _redisCacheService.SetCacheValueAsync("horario", horario, TimeSpan.FromMinutes(30));

                result.Add("Confirmar dados");
                result.Add($"DATA: {horario.ToString("dd/MM/yyyy 'às' HH:mm")}");
                result.Add($"Serviço: {servico.Descricao}");
                result.Add($"Profissional: {medico.Nome}");
                result.Add("1 - Sim");
                result.Add("2 - Não");
            }

            return result;
        }
    }
}
