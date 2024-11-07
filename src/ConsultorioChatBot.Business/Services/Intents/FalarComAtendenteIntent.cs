using ConsultorioChatBot.Business.Interfaces;
using ConsultorioChatBot.Business.Interfaces.Factories;

namespace ConsultorioChatBot.Business.Services.Intents
{
    public class FalarComAtendenteIntent : BaseService, IIntentStrategy
    {
        public FalarComAtendenteIntent(INotificador notificador) : base(notificador)
        {
        }
        public Task<IEnumerable<string>> ObterResposta<T>(T value)
        {
            throw new NotImplementedException();
        }
    }
}
