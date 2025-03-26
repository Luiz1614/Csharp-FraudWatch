using FraudWatch.Domain.Entities;

namespace FraudWatch.Application.Services.Interfaces;

public interface IViaCepApplicationService
{
    Task<ViaCepResponseEntity> GetAddressByCep(string cep);
    string ValidateCep(string cep);
}