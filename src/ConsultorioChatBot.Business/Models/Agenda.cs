namespace ConsultorioChatBot.Business.Models
{
    public class Agenda : Entity
    {
        public string Contato { get; set; }
        public DateTime DataHora { get; set; }
        public bool Confirmacao { get; set; }
        public Servico Servico { get; set; }
        public Medico Medico { get; set; }
    }
}
