using ConsultorioChatBot.Business.Models;

namespace ConsultorioChatBot.Business.Interfaces.Factories
{
    public interface IIntentFactory
    {
        IIntentStrategy GetIntent(IntentsEnumerable tipo);
    }
}
