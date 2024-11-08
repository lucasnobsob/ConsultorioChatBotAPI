using ConsultorioChatBot.Business.Interfaces;
using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Repositories;

namespace ConsultorioChatBot.Business.Services.Intents
{
    public class SelecionarMedicoIntent : BaseService, IIntentStrategy
    {
        private readonly IMedicoRepository _medicoRepository;
        public SelecionarMedicoIntent(INotificador notificador, 
            IMedicoRepository medicoRepository) : base(notificador)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<IEnumerable<string>> ObterResposta<T>(T value)
        {
            var result = new List<string>();
            var medicos = await _medicoRepository.GetAll();
            if (medicos is null || !medicos.Any())
                return new List<string>();

            result.Add("Por favor, informe com qual médico deseja consultar:");
            foreach (var medico in medicos.OrderBy(x => x.Numero))
                result.Add($"{medico.Numero} - {medico.Nome}");

            return result;
        }
    }
}
