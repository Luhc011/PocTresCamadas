using PocTresCamadas.Business.Interfaces;
using PocTresCamadas.Business.Notiticacoes;
using PocTresCamadas.Business.Services;
using PocTresCamadas.Data.Context;
using PocTresCamadas.Data.Repository;

namespace PocTresCamadas.Api.Configurations;

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

