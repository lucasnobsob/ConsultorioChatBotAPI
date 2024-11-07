using ConsultorioChatBot.API.ViewModels;
using ConsultorioChatBot.Business.Interfaces;
using ConsultorioChatBot.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConsultorioChatBot.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly INotificador _notificador;
        public readonly IUser AppUser;

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected BaseController(INotificador notificador,
                                 IUser appUser)
        {
            _notificador = notificador;
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(GetDialogflowResponse(result));
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        private static DialogflowResponseViewModel GetDialogflowResponse(object result)
        {
            var responseList = (List<string>) result;
            var text = new Text { TextItems = responseList.ToList() };
            var fulfillmentMsgs = new List<FulfillmentMessage>() {
                new FulfillmentMessage {
                    Text = text
                }
            };
            var response = new DialogflowResponseViewModel
            {
                FulfillmentMessages = fulfillmentMsgs
            };
            return response;
        }
    }
}
