namespace ConsultorioChatBot.Business.Interfaces.Factories
{
    public interface IIntentStrategy
    {
        Task<IEnumerable<string>> ObterResposta<T>(T value);
    }
}
