using CadastroPessoa.Models;
using CadastroPessoa.Services.Interface;

namespace CadastroPessoa.Services;

public class PessoaService: IPessoaService
{
    private readonly List<Pessoa> _pessoas = new();
    private int _contadorId = 1;

    public List<Pessoa> Listar() => _pessoas;

    public void Adicionar(Pessoa pessoa)
    {
        pessoa.Id = _contadorId++;
        _pessoas.Add(pessoa);
    }
}