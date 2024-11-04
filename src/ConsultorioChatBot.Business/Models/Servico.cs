namespace ConsultorioChatBot.Business.Models
{
    public class Servico : Entity
    {
        public string Descricao { get; set; }

        public TipoServico TipoServico { get; set; }
    }
}
