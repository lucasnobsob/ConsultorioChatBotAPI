using FluentValidation;

namespace ConsultorioChatBot.Business.Models.Validations
{
    public class AgendaValidation : AbstractValidator<Agenda>
    {
        public AgendaValidation()
        {
            RuleFor(x => x.Contato)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\(\d{2}\) \d{5}-\d{4}$").WithMessage("O telefone deve estar no formato (XX) XXXXX-XXXX.");

            RuleFor(x => x.DataHora)
                .NotNull();
        }
    }
}
