using System.ComponentModel.DataAnnotations;

namespace FraudWatch.Application.DTOs;

public class AnalistaDTO
{
    [Required(ErrorMessage = $"O campo {nameof(Nome)} é obrigatório.")]
    [StringLength(150)]
    public string Nome { get; set; }

    [Required(ErrorMessage = $"O campo {nameof(Email)} é obrigatório.")]
    [EmailAddress(ErrorMessage = $"O campo {nameof(Email)} é inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = $"O campo {nameof(DataNascimento)} é obrigatório.")]
    public DateOnly DataNascimento { get; set; }

    [Required(ErrorMessage = $"O campo {nameof(CPF)} é obrigatório.")]
    [StringLength(11)]
    public string CPF { get; set; }

    [Required(ErrorMessage = $"O campo {nameof(Departamento)} é obrigatório.")]
    public string Departamento { get; set; }
}
