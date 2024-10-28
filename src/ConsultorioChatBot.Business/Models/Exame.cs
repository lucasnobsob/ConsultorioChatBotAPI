using ConsultorioChatBot.Business.Models;

namespace ConsultorioChatBot.Business.Models
{
    public class Exame : Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int DuracaoHoras { get; set; }
    }
}
