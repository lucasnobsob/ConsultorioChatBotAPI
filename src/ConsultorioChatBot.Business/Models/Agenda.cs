namespace ConsultorioChatBot.Business.Models
{
    public class Agenda : Entity
    {
        public string Contato { get; set; }
        public DateTime DataHora { get; set; }
        public bool Confirmacao { get; set; }
        public Consulta? Consulta { get; set; }
        public Exame? Exame { get; set; }
    }
}
