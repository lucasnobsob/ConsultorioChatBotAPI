﻿using ConsultorioChatBot.Business.Notificacoes;

namespace ConsultorioChatBot.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}