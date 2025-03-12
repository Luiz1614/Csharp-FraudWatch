using AutoMapper;
using FraudWatch.Application.DTOs;
using FraudWatch.Application.Services.Interfaces;
using FraudWatch.Domain.Entities;
using FraudWatch.Infraestructure.Data.Repositories.Interfaces;

namespace FraudWatch.Application.Services;

public class AnalistaApplicationService : IAnalistaApplicationService
{
    private readonly IAnalistaRepository _analistaRepository;
    private readonly IMapper _mapper;

    public AnalistaApplicationService(IAnalistaRepository analistaRepository, IMapper mapper)
    {
        _analistaRepository = analistaRepository;
        _mapper = mapper;
    }

    public void Add(AnalistaDTO analistaDTO)
    {
        var analistaEntity = _mapper.Map<AnalistaEntity>(analistaDTO);
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
        var analistaEntity = _mapper.Map<AnalistaEntity>(analistaDTO);
        _analistaRepository.UpdateAnalistaByID(id, analistaEntity);
    }
}
