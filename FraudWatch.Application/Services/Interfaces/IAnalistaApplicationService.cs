using FraudWatch.Application.DTOs;
using FraudWatch.Domain.Entities;

namespace FraudWatch.Application.Services.Interfaces;

public interface IAnalistaApplicationService
{
    IEnumerable<AnalistaEntity> GetAll();
    AnalistaEntity GetById(int id);
    AnalistaEntity GetByDepartamento(string departamento);
    void Add(AnalistaDTO analistaDTO);
    void Update(int id, AnalistaDTO analistaDTO);
    void DeleteById(int id);
}
