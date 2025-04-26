using System.ComponentModel.DataAnnotations;

namespace CadastroPessoa.Models;

public class Pessoa
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "A renda mensal é obrigatória.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "A renda deve ser positiva.")]
    public decimal RendaMensal { get; set; }

    public bool MaiorDeIdade =>
        DateTime.Today.AddYears(-18) >= DataNascimento;
}