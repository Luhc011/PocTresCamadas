using PocTresCamadas.Business.Models;

namespace PocTresCamadas.Business.Interfaces;

public interface IProdutoService : IDisposable
{
    Task Adicionar(Produto produto);
    Task Atualizar(Produto produto);
    Task Remover(Guid id);
}
