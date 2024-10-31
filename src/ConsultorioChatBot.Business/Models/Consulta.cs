namespace ConsultorioChatBot.Business.Models
{
    public class Consulta : Entity
    {
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public string NomePaciente { get; set; }

        public IEnumerable<Exame>? Exames { get; set; }
    }
}
