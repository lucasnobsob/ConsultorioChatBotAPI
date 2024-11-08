using ConsultorioChatBot.Business.Interfaces;
using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Repositories;
using ConsultorioChatBot.Business.Interfaces.Services;
using ConsultorioChatBot.Business.Models;

namespace ConsultorioChatBot.Business.Services.Intents
{
    public class NovoAgendamentoIntent : BaseService, IIntentStrategy
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IRedisCacheService _redisCacheService;
        public NovoAgendamentoIntent(INotificador notificador,
            IMedicoRepository medicoRepository,
            IRedisCacheService redisCacheService) : base(notificador)
        {
            _medicoRepository = medicoRepository;
            _redisCacheService = redisCacheService;
        }

        public async Task<IEnumerable<string>> ObterResposta<T>(T value)
        {
            var result = new List<string>();
            IEnumerable<Servico> servicos = null;
            if (value is string numero)
            {
                int.TryParse(numero, out var medicoNumero);
                var medicos = await _medicoRepository.Find(x => x.Numero == medicoNumero);
                var medico = medicos.FirstOrDefault();
                if (medico is null) return new List<string>();
                servicos = await _medicoRepository.GetMedicoServicosAsync(medicoNumero);
                await _redisCacheService.SetCacheValueAsync("medico", medico, TimeSpan.FromMinutes(30));
            }

            if (servicos is null || !servicos.Any())
                return new List<string>();

            result.Add("Qual serviço deseja agendar?");
            result.Add("Digite o número correspondente ao serviço que deseja agendar, ou digite voltar:");

            foreach (var servico in servicos.OrderBy(x => x.Numero))
                result.Add($"{servico.Numero} - {servico.Descricao}");

            return result;
        }
    }
}
