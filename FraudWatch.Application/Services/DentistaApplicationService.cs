using AutoMapper;
using FraudWatch.Application.DTOs;
using FraudWatch.Application.Services.Interfaces;
using FraudWatch.Domain.Entities;
using FraudWatch.Infraestructure.Data.Repositories.Interfaces;

namespace FraudWatch.Application.Services;


public class DentistaApplicationService : IDentistaApplicationService
{
    private readonly IDentistaRepository _dentistaRepository;
    private readonly IMapper _mapper;

    public DentistaApplicationService(IDentistaRepository dentistaRepository, IMapper mapper)
    {
        _dentistaRepository = dentistaRepository;
        _mapper = mapper;
    }

    public void Add(DentistaDTO dentistaDTO)
    {
        var dentistaEntity = _mapper.Map<DentistaEntity>(dentistaDTO);
        _dentistaRepository.AddDentista(dentistaEntity);
    }

    public void DeleteById(int id)
    {
        _dentistaRepository.DeleteDentistaById(id);
    }

    public IEnumerable<DentistaEntity> GetAll()
    {
        return _dentistaRepository.GetAllDentistas();
    }

    public DentistaEntity GetByCro(string cro)
    {
        return _dentistaRepository.GetDentistaByCro(cro);
    }

    public DentistaEntity GetById(int id)
    {
        return _dentistaRepository.GetDentistaById(id);
    }

    public void Update(int id, DentistaDTO dentistaDTO)
    {
        var dentistaEntity = _mapper.Map<DentistaEntity>(dentistaDTO);
        _dentistaRepository.UpdateDentistaById(id, dentistaEntity);
    }
}
