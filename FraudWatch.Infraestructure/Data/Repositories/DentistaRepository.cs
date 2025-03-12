using FraudWatch.Domain.Entities;
using FraudWatch.Infraestructure.Data.AppData;
using FraudWatch.Infraestructure.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FraudWatch.Infraestructure.Data.Repositories;

public class DentistaRepository : IDentistaRepository
{
    private readonly ApplicationContext _context;

    public DentistaRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<DentistaEntity> GetAllDentistas()
    {
        return _context.Set<DentistaEntity>().ToList();
    }

    public DentistaEntity GetDentistaById(int id)
    {
        return _context.Set<DentistaEntity>().Find(id);
    }

    public DentistaEntity GetDentistaByCro(string cro)
    {
        return _context.Set<DentistaEntity>().FirstOrDefault(d => d.CRO == cro);
    }

    public void AddDentista(DentistaEntity entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void DeleteDentistaById(int id)
    {
        var entity = _context.Set<DentistaEntity>().Find(id);
        if (entity != null)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
    }

    public void UpdateDentistaById(int id, DentistaEntity entity)
    {
        var existingEntity = _context.Set<DentistaEntity>().Find(id);

        if (existingEntity != null)
        {
            existingEntity.Nome = entity.Nome;
            existingEntity.Email = entity.Email;
            existingEntity.CPF = entity.CPF;
            existingEntity.DataNascimento = entity.DataNascimento;
            existingEntity.CRO = entity.CRO;

            _context.Entry(existingEntity).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
