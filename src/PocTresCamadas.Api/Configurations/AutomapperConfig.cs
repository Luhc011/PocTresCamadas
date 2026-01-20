using AutoMapper;
using PocTresCamadas.Api.ViewModels;
using PocTresCamadas.Business.Interfaces;
using PocTresCamadas.Business.Models;
using PocTresCamadas.Business.Notiticacoes;
using PocTresCamadas.Business.Services;
using PocTresCamadas.Data.Context;
using PocTresCamadas.Data.Repository;

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

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        // data
        services.AddScoped<MeuDbContext>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IFornecedorRepository, FornecedorRepository>();

        // business
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IFornecedorService, FornecedorService>();
        services.AddScoped<INotificador, Notificador>();

        return services;
    }
}

