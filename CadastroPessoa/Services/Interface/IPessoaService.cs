using CadastroPessoa.Models;

namespace CadastroPessoa.Services.Interface;

public interface IPessoaService
{
    List<Pessoa> Listar();
    void Adicionar(Pessoa pessoa);
}