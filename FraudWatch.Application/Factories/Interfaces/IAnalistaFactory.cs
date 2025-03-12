using FraudWatch.Application.DTOs;

namespace FraudWatch.Application.Factories.Interfaces
{
    public interface IAnalistaFactory
    {
        AnalistaDTO CreateAnalista(string nome, string email, DateOnly dataNascimento, string cpf, string departamento);
    }
}