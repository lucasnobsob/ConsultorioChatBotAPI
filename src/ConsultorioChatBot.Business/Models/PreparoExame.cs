using ConsultorioChatBot.Business.Models;

namespace ConsultorioChatBot.Business.Models
{
    public class PreparoExame : Entity
    {
        public string Texto { get; set; }

        public Exame Exame { get; set; }
    }
}
