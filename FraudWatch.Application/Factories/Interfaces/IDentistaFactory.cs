using FraudWatch.Application.DTOs;

namespace FraudWatch.Application.Factories.Interfaces
{
    public interface IDentistaFactory
    {
        DentistaDTO CreateDentista(string nome, string email, DateOnly dataNascimento, string cpf, string cro);
    }
}