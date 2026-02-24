using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocTresCamadas.Api.ViewModels;
using PocTresCamadas.Business.Interfaces;
using PocTresCamadas.Business.Models;
using System.Net;

namespace PocTresCamadas.Api.Controllers;

[Route("api/fornecedores")]
public class FornecedoresControler : MainController
{
    private readonly IFornecedorRepository _fornecedorRepository;
    private readonly IFornecedorService _fornecedorService;
    private readonly IMapper _mapper;
    public FornecedoresControler(IFornecedorRepository fornecedorRepository, IFornecedorService fornecedorService, IMapper mapper, INotificador notificador) : base(notificador)
    {
        _fornecedorRepository = fornecedorRepository;
        _fornecedorService = fornecedorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
    {
        return _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> ObterPorId(Guid id)
    {
        var fornecedorVm = await ObterFornecedor(id);

        if (fornecedorVm is null) return NotFound();

        return fornecedorVm;
    }

    [HttpPost]
    public async Task<ActionResult<FornecedorViewModel>> Adicionar(FornecedorViewModel fornecedorViewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorViewModel));

        return CustomResponse(HttpStatusCode.Created, fornecedorViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, FornecedorViewModel fornecedorViewModel)
    {
        if (id != fornecedorViewModel.Id)
        {
            NotificarErro("os ids informados nao sao iguais");
            return CustomResponse();
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(fornecedorViewModel));

        return CustomResponse(HttpStatusCode.NoContent);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id)
    {
        await _fornecedorService.Remover(id);

        return CustomResponse(HttpStatusCode.NoContent);
    }

    private async Task<FornecedorViewModel> ObterFornecedor(Guid id)
    {
        return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
    }

}
