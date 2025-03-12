using FraudWatch.Domain.Entities;
using FraudWatch.Infraestructure.Data.AppData;
using FraudWatch.Infraestructure.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FraudWatch.Infraestructure.Data.Repositories;

public class AnalistaRepository : IAnalistaRepository
{
    private readonly ApplicationContext _context;

    public AnalistaRepository(ApplicationContext context)
    {
        _context=context;
    }

    public void AddAnalista(AnalistaEntity entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void DeleteAnalistaById(int id)
    {
        var entity = _context.Set<AnalistaEntity>().Find(id);
        if (entity != null)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
    }

    public IEnumerable<AnalistaEntity> GetAllAnalistas()
    {
        return _context.Set<AnalistaEntity>().ToList();
    }

    public AnalistaEntity GetAnalistaByDepartamento(string departamento)
    {
        return _context.Analistas.SingleOrDefault(d => d.Departamento == departamento);
    }

    public AnalistaEntity GetAnalistaById(int id)
    {
        return _context.Set<AnalistaEntity>().Find(id);
    }

    public void UpdateAnalistaByID(int id, AnalistaEntity entity)
    {
        var existingEntity = _context.Set<AnalistaEntity>().Find(id);

        if (existingEntity != null)
        {
            existingEntity.Nome = entity.Nome;
            existingEntity.Email = entity.Email;
            existingEntity.CPF = entity.CPF;
            existingEntity.DataNascimento = entity.DataNascimento;
            existingEntity.Departamento = entity.Departamento;

            _context.Entry(existingEntity).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
