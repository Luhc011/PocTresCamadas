using PocTresCamadas.Business.Interfaces;

namespace PocTresCamadas.Business.Notiticacoes;

public class Notificador : INotificador
{
    private List<Notificacao> _notificacoes;

    public Notificador()
    {
        _notificacoes = [];
    }

    public void Handle(Notificacao notificacao)
    {
        _notificacoes.Add(notificacao);
    }

    public List<Notificacao> ObterNotificacoes()
    {
        return _notificacoes;
    }

    public bool TemNotificacao()
    {
        return _notificacoes.Any();
    }
}