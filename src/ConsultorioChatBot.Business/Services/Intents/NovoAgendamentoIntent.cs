using ConsultorioChatBot.Business.Interfaces;
using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Repositories;
using System.Text;

namespace ConsultorioChatBot.Business.Services.Intents
{
    public class NovoAgendamentoIntent : BaseService, IIntentStrategy
    {
        private readonly IServicoRepository _servicoRepository;
        public NovoAgendamentoIntent(INotificador notificador,
            IServicoRepository servicoRepository) : base(notificador)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<IEnumerable<string>> ObterResposta<T>(T value)
        {
            var result = new List<string>();
            var servicos = await _servicoRepository.ObterListaServicos();
            if (servicos is null || !servicos.Any())
                return new List<string>();

            result.Add("Qual serviço deseja agendar? \n\n");
            result.Add("Digite o número correspondente ao serviço que deseja agendar, ou digite voltar:\n\n");

            foreach (var (servico, index) in servicos.Select((value, index) => (value, index)))
                result.Add($"{index + 1} - {servico.Descricao}\n");

            return result;
        }
    }
}
