using Microsoft.AspNetCore.Mvc;
using PocTresCamadas.Api.ViewModels;

namespace PocTresCamadas.Api.Controllers;

public class FornecedoresControler : MainController
{
    public FornecedoresControler()
    {
    }

    [HttpGet]
    public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
    {
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> ObterPorId(Guid id)
    {
    }

    [HttpPost]
    public async Task<ActionResult<FornecedorViewModel>> Adicionar(FornecedorViewModel fornecedorViewModel)
    {
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, FornecedorViewModel fornecedorViewModel)
    {
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id)
    {
    }

}
