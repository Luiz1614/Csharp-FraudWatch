using FraudWatch.Application.DTOs;
using FraudWatch.Application.Factories.Interfaces;

namespace FraudWatch.Application.Factories;

public class DentistaFactory : IDentistaFactory
{
    public DentistaDTO CreateDentista(string nome, string email, DateOnly dataNascimento, string cpf, string cro)
    {
        return new DentistaDTO
        {
            Nome = nome,
            Email = email,
            DataNascimento = dataNascimento,
            CPF = cpf,
            CRO = cro
        };
    }
}
