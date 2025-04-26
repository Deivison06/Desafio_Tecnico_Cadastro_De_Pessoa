using CadastroPessoa.Models;
using CadastroPessoa.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CadastroPessoa.Controllers;

public class PessoaController : Controller
{
    private readonly IPessoaService _pessoaService;
    private readonly ILogger<PessoaController> _logger;
    
    public PessoaController(IPessoaService pessoaService, ILogger<PessoaController> logger)
    
    {
        _pessoaService = pessoaService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Acessando a lista de pessoas.");
        var pessoas = _pessoaService.Listar();
        return View(pessoas);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Pessoa pessoa)
    {
        if (!pessoa.MaiorDeIdade)
        {
            _logger.LogWarning("Pessoa menor de idade tentou se cadastrar.");
            ModelState.AddModelError("DataNascimento", "A pessoa deve ser maior de 18 anos.");
        }

        if (ModelState.IsValid)
        {
            _pessoaService.Adicionar(pessoa);
            _logger.LogInformation("Pessoa adicionada com sucesso: {@Pessoa}", pessoa);
            return RedirectToAction("Index");
        }

        _logger.LogWarning("Erro ao criar pessoa. Dados inválidos: {@Pessoa}", pessoa);
        return View(pessoa);
    }
}