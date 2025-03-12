using FraudWatch.Domain.Entities;

namespace FraudWatch.Infraestructure.Data.Repositories.Interfaces;

public interface IAnalistaRepository
{
    IEnumerable<AnalistaEntity> GetAllAnalistas();
    AnalistaEntity GetAnalistaById(int id);
    AnalistaEntity GetAnalistaByDepartamento(string departamento);
    void AddAnalista(AnalistaEntity entity);
    void UpdateAnalistaByID(int id, AnalistaEntity entity);
    void DeleteAnalistaById(int id);
}
