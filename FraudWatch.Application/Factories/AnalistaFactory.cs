using FraudWatch.Application.DTOs;
using FraudWatch.Application.Factories.Interfaces;

namespace FraudWatch.Application.Factories;

public class AnalistaFactory : IAnalistaFactory
{
    public AnalistaDTO CreateAnalista(string nome, string email, DateOnly dataNascimento, string cpf, string departamento)
    {
        return new AnalistaDTO
        {
            Nome = nome,
            Email = email,
            DataNascimento = dataNascimento,
            CPF = cpf,
            Departamento = departamento
        };
    }
}
