using Microsoft.EntityFrameworkCore;
using PocTresCamadas.Business.Interfaces;
using PocTresCamadas.Business.Models;
using PocTresCamadas.Data.Context;

namespace PocTresCamadas.Data.Repository;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(MeuDbContext context) : base(context) { }

    public async Task<Produto?> ObterProdutoFornecedor(Guid id)
    {
        return await Db.Produtos.AsNoTracking()
            .Include(f => f.Fornecedor) // join com a tabela Fornecedor
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
    {
        return await Db.Produtos.AsNoTracking()
            .Include(f => f.Fornecedor)
            .OrderBy(p => p.Nome)
            .ToListAsync();
    }

    public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
    {
        return await Buscar(p => p.FornecedorId == fornecedorId);
    }
}