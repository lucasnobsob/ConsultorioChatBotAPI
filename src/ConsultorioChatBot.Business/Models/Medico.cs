namespace ConsultorioChatBot.Business.Models
{
    public class Medico : Entity
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string CRM { get; set; }

        public IEnumerable<Servico> Servicos { get; set; }
    }
}
