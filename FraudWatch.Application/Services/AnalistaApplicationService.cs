using FraudWatch.Application.DTOs;
using FraudWatch.Application.Interfaces;
using FraudWatch.Domain.Entities;
using FraudWatch.Infraestructure.Data.Repositories;

namespace FraudWatch.Application.Services;

public class AnalistaApplicationService : IAnalistaApplicationService
{
    private readonly IAnalistaRepository _analistaRepository;

    public AnalistaApplicationService(IAnalistaRepository analistaRepository)
    {
        _analistaRepository=analistaRepository;
    }

    public void Add(AnalistaDTO analistaDTO)
    {
        var analistaEntity = new AnalistaEntity
        {
            Nome = analistaDTO.Nome,
            Email = analistaDTO.Email,
            CPF = analistaDTO.CPF,
            Departamento = analistaDTO.Departamento
        };

        _analistaRepository.AddAnalista(analistaEntity);
    }

    public void DeleteById(int id)
    {
        _analistaRepository.DeleteAnalistaById(id);
    }

    public IEnumerable<AnalistaEntity> GetAll()
    {
        return _analistaRepository.GetAllAnalistas();
    }

    public AnalistaEntity GetByDepartamento(string departamento)
    {
        return _analistaRepository.GetAnalistaByDepartamento(departamento);
    }

    public AnalistaEntity GetById(int id)
    {
        return _analistaRepository.GetAnalistaById(id);
    }

    public void Update(int id, AnalistaDTO analistaDTO)
    {
        _analistaRepository.UpdateAnalistaByID(id, new AnalistaEntity
        {
            Nome = analistaDTO.Nome,
            Email = analistaDTO.Email,
            CPF = analistaDTO.CPF,
            Departamento = analistaDTO.Departamento
        });
    }
}
