using System.Net;
using FraudWatch.Application.DTOs;
using FraudWatch.Application.Factories.Interfaces;
using FraudWatch.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FraudWatch.Presentation.Controller;

[ApiController]
[Route("api/[controller]")]
public class AnalistaController : ControllerBase
{
    private readonly IAnalistaApplicationService _analistaApplicationService;
    private readonly IAnalistaFactory _analistaFactory;

    public AnalistaController(IAnalistaApplicationService analistaApplicationService, IAnalistaFactory analistaFactory)
    {
        _analistaApplicationService = analistaApplicationService;
        _analistaFactory = analistaFactory;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retorna uma lista de todos os analistas.")]
    [SwaggerResponse(200, "Analistas obtidos com sucesso.")]
    [SwaggerResponse(204, "Nenhum analista encontrado.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult GetAllAnalistas()
    {
        try
        {
            var clientes = _analistaApplicationService.GetAll();

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
    [SwaggerOperation(Summary = "Retorna um analista pelo ID.")]
    [SwaggerResponse(200, "Analista obtido com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(404, "Analista não encontrado.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult GetAnalistaById(int id)
    {
        try
        {
            var cliente = _analistaApplicationService.GetById(id);

            if (cliente == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            return StatusCode((int)HttpStatusCode.OK, cliente);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpGet("departamento/{departamento}")]
    [SwaggerOperation(Summary = "Retorna um analista pelo departamento.")]
    [SwaggerResponse(200, "Analista obtido com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(404, "Analista não encontrado.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult GetAnalistaByDepartamento(string departamento)
    {
        try
        {
            var cliente = _analistaApplicationService.GetByDepartamento(departamento);

            if (cliente == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            return StatusCode((int)HttpStatusCode.OK, cliente);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Adiciona um novo analista.")]
    [SwaggerResponse(201, "Analista adicionado com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult PostAnalista([FromBody] AnalistaDTO analistaDTO)
    {
        try
        {
            var analista = _analistaFactory.CreateAnalista(analistaDTO.Nome, analistaDTO.Email, analistaDTO.DataNascimento, analistaDTO.CPF, analistaDTO.Departamento);
            _analistaApplicationService.Add(analistaDTO);
            return StatusCode((int)HttpStatusCode.Created);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualiza um analista pelo ID.")]
    [SwaggerResponse(200, "Analista atualizado com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult PutAnalista(int id, [FromBody] AnalistaDTO analistaDTO)
    {
        try
        {
            _analistaApplicationService.Update(id, analistaDTO);
            return StatusCode((int)HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deleta um analista pelo ID.")]
    [SwaggerResponse(204, "Analista deletado com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida. Verifique os dados fornecidos.")]
    [SwaggerResponse(500, "Erro interno no servidor.")]
    public IActionResult DeleteAnalista(int id)
    {
        try
        {
            _analistaApplicationService.DeleteById(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

}
