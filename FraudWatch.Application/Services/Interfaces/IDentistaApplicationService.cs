using FraudWatch.Application.DTOs;
using FraudWatch.Domain.Entities;

namespace FraudWatch.Application.Services.Interfaces;

public interface IDentistaApplicationService
{
    IEnumerable<DentistaEntity> GetAll();
    DentistaEntity GetById(int id);
    DentistaEntity GetByCro(string cro);
    void Add(DentistaDTO dentistaDTO);
    void Update(int id, DentistaDTO dentistaDTO);
    void DeleteById(int id);
}
