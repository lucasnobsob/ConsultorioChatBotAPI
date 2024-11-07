using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Models;

namespace ConsultorioChatBot.Business.Factories
{
    public class IntentFactory : IIntentFactory
    {
        private readonly Dictionary<IntentsEnumerable, IIntentStrategy> _services;

        public IntentFactory(IEnumerable<IIntentStrategy> services)
        {
            _services = services.ToDictionary(
                servico => (IntentsEnumerable) Enum.Parse(typeof(IntentsEnumerable), servico.GetType().Name),
                servico => servico
            );
        }

        public IIntentStrategy GetIntent(IntentsEnumerable tipo)
        {
            return _services.TryGetValue(tipo, out var servico) ? servico : throw new InvalidOperationException("Serviço não encontrado.");
        }
    }
}
