namespace ConsultorioChatBot.Business.Models
{
    public class Servico : Entity
    {
        public int Numero { get; set; }
        public string Descricao { get; set; }
        public string? PreparoExame { get; set; }
        public TipoServico TipoServico { get; set; }

        public IEnumerable<Medico> Medicos { get; set; }
    }
}
