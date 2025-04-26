using CadastroPessoa.Models;
using CadastroPessoa.Services.Interface;

namespace CadastroPessoa.Services;

public class PessoaService : IPessoaService
{
    private readonly List<Pessoa> _pessoas = new();
    private int _contadorId = 1;

    public PessoaService()
    {
        // Dados mockados
        var nomes = new[]
        {
            "Ana Souza", "Bruno Lima", "Carla Mendes", "Daniel Rocha", "Elaine Castro",
            "Felipe Silva", "Gabriela Torres", "Henrique Almeida", "Isabela Costa", "João Pedro"
        };

        var random = new Random();

        foreach (var nome in nomes)
        {
            var pessoa = new Pessoa
            {
                Id = _contadorId++,
                Nome = nome,
                DataNascimento = DateTime.Now.AddYears(-random.Next(20, 50)).AddDays(random.Next(0, 365)),
                RendaMensal = random.Next(1500, 8000)
            };

            _pessoas.Add(pessoa);
        }
    }

    public List<Pessoa> Listar(string filtro, int pagina, int tamanhoPagina, out int totalPessoas)
    {
        var query = _pessoas.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filtro))
        {
            query = query.Where(p => p.Nome.Contains(filtro, StringComparison.OrdinalIgnoreCase));
        }

        totalPessoas = query.Count();

        return query
            .Skip((pagina - 1) * tamanhoPagina)
            .Take(tamanhoPagina)
            .ToList();
    }

    public void Adicionar(Pessoa pessoa)
    {
        pessoa.Id = _contadorId++;
        _pessoas.Add(pessoa);
    }
}
