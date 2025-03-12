using System.Net;
using FraudWatch.Application.DTOs;
using FraudWatch.Application.Factories.Interfaces;
using FraudWatch.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FraudWatch.Presentation.Controller;

[ApiController]
[Route("api/[controller]")]
public class DentistaController : ControllerBase
{
    private readonly IDentistaApplicationService _dentistaApplicationService;
    private readonly IDentistaFactory _dentistaFactory;

    public DentistaController(IDentistaApplicationService dentistaApplicationService, IDentistaFactory dentistaFactory)
    {
        _dentistaApplicationService = dentistaApplicationService;
        _dentistaFactory = dentistaFactory;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retorna uma lista de todos os dentistas.")]
    [SwaggerResponse(200, "Dentistas obtidos com sucesso.")]
    [SwaggerResponse(204, "Nenhum dentista encontrado.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult GetAllDentistas()
    {
        try
        {
            var clientes = _dentistaApplicationService.GetAll();

            if (clientes == null)
                return StatusCode((int)HttpStatusCode.NoContent);

            return StatusCode((int)HttpStatusCode.OK, clientes);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Retorna um dentista pelo ID.")]
    [SwaggerResponse(200, "Dentista obtido com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(404, "Dentista não encontrado.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult GetDentistaById(int id)
    {
        try
        {
            var cliente = _dentistaApplicationService.GetById(id);

            if (cliente == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            return StatusCode((int)HttpStatusCode.OK, cliente);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpGet("cro/{cro}")]
    [SwaggerOperation(Summary = "Retorna um dentista pelo CRO.")]
    [SwaggerResponse(200, "Dentista obtido com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(404, "Dentista não encontrado.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult GetDentistaByCro(string cro)
    {
        try
        {
            var cliente = _dentistaApplicationService.GetByCro(cro);

            if (cliente == null)
                return StatusCode((int) HttpStatusCode.NotFound);

            return StatusCode((int) HttpStatusCode.OK, cliente);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Adiciona um novo dentista.")]
    [SwaggerResponse(201, "Dentista adicionado com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult PostDentista([FromBody] DentistaDTO dentistaDTO)
    {
        try
        {
            var dentista = _dentistaFactory.CreateDentista(dentistaDTO.Nome, dentistaDTO.Email, dentistaDTO.DataNascimento, dentistaDTO.CPF, dentistaDTO.CRO);
            _dentistaApplicationService.Add(dentistaDTO);
            return StatusCode((int)HttpStatusCode.Created);
        }
        catch (Exception ex)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualiza um dentista pelo ID.")]
    [SwaggerResponse(200, "Dentista atualizado com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult PutDentista(int id, [FromBody] DentistaDTO dentistaDTO)
    {
        try
        {
            _dentistaApplicationService.Update(id, dentistaDTO);
            return StatusCode((int) HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deleta um dentista pelo ID.")]
    [SwaggerResponse(204, "Dentista deletado com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult DeleteDentista(int id)
    {
        try
        {
            _dentistaApplicationService.DeleteById(id);
            return StatusCode((int) HttpStatusCode.NoContent);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}


