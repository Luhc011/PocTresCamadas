using PocTresCamadas.Business.Notiticacoes;

namespace PocTresCamadas.Business.Interfaces;

public interface INotificador
{
    bool TemNotificacao();
    List<Notificacao> ObterNotificacoes();
    void Handle(Notificacao notificacao);
}
