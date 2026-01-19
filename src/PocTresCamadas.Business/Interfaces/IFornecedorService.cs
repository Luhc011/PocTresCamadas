using PocTresCamadas.Business.Models;

namespace PocTresCamadas.Business.Interfaces;

public interface IFornecedorService : IDisposable
{
    Task Adicionar(Fornecedor fornecedor);
    Task Atualizar(Fornecedor fornecedor);
    Task Remover(Guid id);
}
