using AutoMapper;
using PocTresCamadas.Api.ViewModels;
using PocTresCamadas.Business.Models;

namespace PocTresCamadas.Api.Configurations;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
        CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        CreateMap<ProdutoViewModel, Produto>();

        CreateMap<Produto, ProdutoViewModel>()
            .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
    }
}

