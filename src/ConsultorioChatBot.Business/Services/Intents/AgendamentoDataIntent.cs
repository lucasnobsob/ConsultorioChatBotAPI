using ConsultorioChatBot.Business.Helpers;
using ConsultorioChatBot.Business.Interfaces;
using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Repositories;
using ConsultorioChatBot.Business.Interfaces.Services;
using ConsultorioChatBot.Business.Models;
using System.Globalization;

namespace ConsultorioChatBot.Business.Services.Intents
{
    public class AgendamentoDataIntent : BaseService, IIntentStrategy
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IRedisCacheService _redisCacheService;
        public AgendamentoDataIntent(INotificador notificador,
            IServicoRepository servicoRepository,
            IRedisCacheService redisCacheService) : base(notificador)
        {
            _servicoRepository = servicoRepository;
            _redisCacheService = redisCacheService;
        }

        public async Task<IEnumerable<string>> ObterResposta<T>(T value)
        {
            var result = new List<string>();
            var medico = await _redisCacheService.GetCacheValueAsync<Medico>("medico");

            if (value is string numero)
            {
                int.TryParse(numero, out var servicoNumero);
                var servicos = await _servicoRepository.Find(x => x.Numero == servicoNumero);
                var servico = servicos.FirstOrDefault();
                if (servico is null) return new List<string>();
                await _redisCacheService.SetCacheValueAsync("servico", servico, TimeSpan.FromMinutes(30));
            }

            var datasDisponiveis = DateHelper.GetDaysOfWeek();

            result.Add("Qual a data que deseja marcar?");
            result.Add("Digite em qual data deseja agendar, 6 para outras datas ou voltar:");

            foreach (var data in datasDisponiveis)
            {
                result.Add($"{data.Item1} - {data.Item2.ToString("dddd", new CultureInfo("pt-BR"))}");
                result.Add($"{data.Item2.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("pt-BR"))}");
            }

            return result;
        }
    }
}
