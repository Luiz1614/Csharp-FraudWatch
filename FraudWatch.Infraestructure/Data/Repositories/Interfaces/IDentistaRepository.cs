using FraudWatch.Domain.Entities;

namespace FraudWatch.Infraestructure.Data.Repositories.Interfaces;

public interface IDentistaRepository
{
    IEnumerable<DentistaEntity> GetAllDentistas();
    DentistaEntity GetDentistaById(int id);
    DentistaEntity GetDentistaByCro(string cro);
    void AddDentista(DentistaEntity entity);
    void UpdateDentistaById(int id, DentistaEntity entity);
    void DeleteDentistaById(int id);
}
