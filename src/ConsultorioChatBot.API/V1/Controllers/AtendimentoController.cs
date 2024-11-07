using ConsultorioChatBot.API.Controllers;
using ConsultorioChatBot.API.ViewModels;
using ConsultorioChatBot.Business.Interfaces;
using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Services;
using ConsultorioChatBot.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioChatBot.API.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    [Route("api/v{version:apiVersion}/atendimento")]
    public class AtendimentoController : BaseController
    {
        private readonly IIntentFactory _intentFactory;
        private readonly IRedisCacheService _redisCacheService;

        public AtendimentoController(INotificador notificador,
            IUser user, IIntentFactory intentFactory,
            IRedisCacheService userChoiceService) : base(notificador, user)
        {
            _intentFactory = intentFactory;
            _redisCacheService = userChoiceService;
        }

        [HttpPost("processar-intencoes")]
        [AllowAnonymous]
        public async Task<IActionResult> ProcessarIntencoes([FromBody] DialogflowRequestViewModel payload)
        {
            var intentName = (IntentsEnumerable)Enum.Parse(typeof(IntentsEnumerable), $"{payload.QueryResult.Intent.DisplayName}Intent");
            var intent = _intentFactory.GetIntent(intentName);
            var result = await intent.ObterResposta("");

            return CustomResponse(result);
        }
    }
}
