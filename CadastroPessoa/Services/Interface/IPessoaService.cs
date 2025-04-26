using CadastroPessoa.Models;

namespace CadastroPessoa.Services.Interface;

public interface IPessoaService
{
    List<Pessoa> Listar(string filtro, int pagina, int tamanhoPagina, out int totalPessoas);
    void Adicionar(Pessoa pessoa);
}