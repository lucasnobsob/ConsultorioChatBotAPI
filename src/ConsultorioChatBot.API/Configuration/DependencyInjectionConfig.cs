using ConsultorioChatBot.Api.Extensions;
using ConsultorioChatBot.Business.Factories;
using ConsultorioChatBot.Business.Interfaces;
using ConsultorioChatBot.Business.Interfaces.Factories;
using ConsultorioChatBot.Business.Interfaces.Repositories;
using ConsultorioChatBot.Business.Interfaces.Services;
using ConsultorioChatBot.Business.Notificacoes;
using ConsultorioChatBot.Business.Services;
using ConsultorioChatBot.Business.Services.Intents;
using ConsultorioChatBot.Data.Context;
using ConsultorioChatBot.Data.Repository;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ConsultorioChatBot.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ConsultorioDbContext>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IAgendaRepository, AgendaRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IIntentFactory, IntentFactory>();
            services.AddScoped<IIntentStrategy, AgendamentoDataIntent>();
            services.AddScoped<IIntentStrategy, AgendamentoHorarioIntent>();
            services.AddScoped<IIntentStrategy, CancelarAgendamentoIntent>();
            services.AddScoped<IIntentStrategy, FalarComAtendenteIntent>();
            services.AddScoped<IIntentStrategy, NovoAgendamentoIntent>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}