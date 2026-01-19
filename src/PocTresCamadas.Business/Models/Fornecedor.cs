namespace PocTresCamadas.Business.Models;

public class Fornecedor : Entity
{
    public string Nome { get; set; } = string.Empty;
    public string Documento { get; set; } = string.Empty;
    public TipoFornecedor TipoFornecedor { get; set; }
    public bool Ativo { get; set; }
    public Endereco? Endereco { get; set; }

    /* EF Relation */
    public IEnumerable<Produto> Produtos { get; set; } = [];
}

public enum TipoFornecedor
{
    PessoaFisica = 1,
    PessoaJuridica
}